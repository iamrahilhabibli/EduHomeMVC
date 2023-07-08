using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels;
using EduHomeUI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Services.Concretes
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CourseService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<bool> CreateCourseAsync(CourseViewModel courses)
        {
            if (courses is null) return false;

            var languageOption = await _context.Languages.FindAsync(courses.LanguageOptionId);
            var assesment = await _context.Assesments.FindAsync(courses.AssesmentId);
            var skillLevel = await _context.SkillLevels.FindAsync(courses.SkillLevelId);
            var courseCategory = await _context.courseCategories.FindAsync(courses.CourseCategoryId);

            if (languageOption is null || assesment is null || skillLevel is null || courseCategory is null)
                return false;

            var courseDetail = _mapper.Map<CourseViewModel, CourseDetails>(courses);
            courseDetail.LanguageOption = languageOption;
            courseDetail.Skill = skillLevel;
            courseDetail.Assesment = assesment;
            courseDetail.DateCreated = DateTime.Now;
            courseDetail.DateModified = DateTime.Now;

            var course = _mapper.Map<CourseViewModel, Course>(courses);
            course.CourseCategory = courseCategory;
            course.Details = courseDetail;
            course.DateModified = DateTime.Now;
            course.DateCreated = DateTime.Now;

            _context.courseDetails.Add(courseDetail);
            _context.courses.Add(course);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Course>> GetAllCourseAsync()
        {
            return await _context.courses.ToListAsync();
        }


        public async Task<bool> GetCourseById(Guid courseId)
        {
            var course = await _context.courses.FindAsync(courseId);
            if (course is null) return false;
            return true;
        }
        public async Task<Course> GetCourseByIdCourse(Guid courseId)
        {
            return await _context.courses.FindAsync(courseId);
        }

        public async Task<bool> UpdateCourseIsDeleted(Guid courseId, bool isDeleted)
        {
            var course = await _context.courses.FindAsync(courseId);
            if (course is null) return false;

            course.IsDeleted = isDeleted;
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> UpdateCourseDetailIsDeleted(Guid courseDetailId, bool isDeleted)
        {
            var courseDetail = await _context.courseDetails.FindAsync(courseDetailId);
            if (courseDetail is null) return false;

            courseDetail.IsDeleted = isDeleted;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCourseById(Guid courseId)
        {
            var course = await _context.courses.FindAsync(courseId);

            if (course is null)
            {
                return false;
            }

            course.IsDeleted = true;
            _context.courses.Update(course);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> GetCourseDetailById(Guid courseId)
        {
            var courseDetail = await _context.courseDetails.FindAsync(courseId);
            if (courseDetail is null) return false;
            return true;
        }
		public async Task<CourseDetails> GetCourseDetailsAsync(Guid courseId)
		{
            var courseDetails = await _context.courseDetails
            .FirstOrDefaultAsync(cd => cd.Course.Id == courseId);
            return courseDetails;
        }
        public async Task<CourseViewModel> MapCourseVM(Course course)
        {
            var courseViewModel = _mapper.Map<CourseViewModel>(course);

            return courseViewModel;
        }
    }
}
