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
            if (courses is null)
                return false;

            var languageOption = await _context.Languages.FindAsync(courses.LanguageOptionId);
            var assesment = await _context.Assesments.FindAsync(courses.AssesmentId);
            var skillLevel = await _context.SkillLevels.FindAsync(courses.SkillLevelId);
            var courseCategory = await _context.CourseCategories.FindAsync(courses.CourseCategoryId);

            if (languageOption is null || assesment is null || skillLevel is null || courseCategory is null)
                return false;

            var courseDetail = _mapper.Map<CourseViewModel, CourseDetails>(courses);
            var course = _mapper.Map<CourseViewModel, Course>(courses);

          
            course.Details = courseDetail;

            var courseDetailsLanguage = new CourseDetailsLanguage
            {
                LanguageId = languageOption.Id,
                CourseDetailsId = courseDetail.Id
            };

            var courseDetailsSkillLevel = new CourseDetailsSkillLevel
            {
                SkillLevelId = skillLevel.Id,
                CourseDetailsId = courseDetail.Id
            };

            var courseDetailsAssesment = new CourseDetailsAssesment
            {
                AssesmentId = assesment.Id,
                CourseDetailsId = courseDetail.Id
            };

            courseDetail.CourseDetailsLanguages.Add(courseDetailsLanguage);
            courseDetail.CourseDetailsSkillLevels.Add(courseDetailsSkillLevel);
            courseDetail.CourseDetailsAssesments.Add(courseDetailsAssesment);

            _context.CourseDetails.Add(courseDetail);
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<List<Course>> GetAllCourseAsync()
        {
            return await _context.Courses.ToListAsync();
        }


        public async Task<bool> GetCourseById(Guid courseId)
        {
            var course = await _context.Courses.FindAsync(courseId);
            if (course is null) return false;
            return true;
        }
        public async Task<Course> GetCourseByIdCourse(Guid courseId)
        {
            return await _context.Courses.FindAsync(courseId);
        }

        public async Task<bool> UpdateCourseIsDeleted(Guid courseId, bool isDeleted)
        {
            var course = await _context.Courses.FindAsync(courseId);
            if (course is null) return false;

            course.IsDeleted = isDeleted;
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> UpdateCourseDetailIsDeleted(Guid courseId, bool isDeleted)
        {
            var courseDetail = await _context.CourseDetails.FirstOrDefaultAsync(cd => cd.CourseId == courseId);
            if (courseDetail == null) return false;

            courseDetail.IsDeleted = isDeleted;
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> DeleteCourseById(Guid courseId)
        {
            var course = await _context.Courses.FindAsync(courseId);

            if (course is null)
            {
                return false;
            }

            course.IsDeleted = true;
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> GetCourseDetailExists(Guid courseId)
        {
            return await _context.CourseDetails.AnyAsync(cd => cd.CourseId == courseId);
        }

        public async Task<CourseDetails> GetCourseDetailsAsync(Guid courseId)
        {
            var courseDetails = await _context.CourseDetails
            .FirstOrDefaultAsync(cd => cd.Course.Id == courseId);
            return courseDetails;
        }
        public async Task<CourseViewModel> MapCourseVM(Course course)
        {
            var courseWithDetails = await _context.Courses
                .Include(c => c.Details)
                .FirstOrDefaultAsync(c => c.Id == course.Id);

            if (courseWithDetails == null)
            {
                return null;
            }

            var courseViewModel = new CourseViewModel
            {
                Name = courseWithDetails.Name,
                Description = courseWithDetails.Description,
                ImagePath = courseWithDetails.ImagePath,
                ImageName = courseWithDetails.ImageName,
                CourseCategoryId = courseWithDetails.CourseCategoryId
            };

            if (courseWithDetails.Details != null)
            {
                courseViewModel.Start = courseWithDetails.Details.Start;
                courseViewModel.Duration = courseWithDetails.Details.Duration;
                courseViewModel.ClassDuration = courseWithDetails.Details.ClassDuration;
                courseViewModel.CourseFee = courseWithDetails.Details.CourseFee;
                courseViewModel.StudentCount = courseWithDetails.Details.StudentCount;
                courseViewModel.LanguageOptionId = courseWithDetails.Details.LanguageOptionId;
                courseViewModel.AssesmentId = courseWithDetails.Details.AssesmentId;
                courseViewModel.SkillLevelId = courseWithDetails.Details.SkillLevelId;
            }

            return courseViewModel;
        }

        public async Task<bool> UpdateCourseAsync(Guid courseId, CourseViewModel courses)
        {
            Course course = await _context.Courses.Include(c => c.Details).FirstOrDefaultAsync(c => c.Id == courseId);
            if (course == null)
            {
                return false;
            }

            course.Name = courses.Name;
            course.Description = courses.Description;
            course.ImagePath = courses.ImagePath;

            if (course.Details != null)
            {
                course.Details.Start = courses.Start;
                course.Details.Duration = courses.Duration;
                course.Details.ClassDuration = courses.ClassDuration;
                course.Details.LanguageOptionId = courses.LanguageOptionId;
                course.Details.AssesmentId = courses.AssesmentId;
                course.Details.SkillLevelId = courses.SkillLevelId;
                course.Details.CourseFee = courses.CourseFee;

                _context.Entry(course.Details).State = EntityState.Modified;
            }
            else
            {
                CourseDetails newDetails = new CourseDetails
                {
                    Start = courses.Start,
                    Duration = courses.Duration,
                    ClassDuration = courses.ClassDuration,
                    LanguageOptionId = courses.LanguageOptionId,
                    SkillLevelId = courses.SkillLevelId,
                    AssesmentId = courses.AssesmentId,
                    CourseFee = courses.CourseFee,
                    StudentCount = courses.StudentCount
                };
                course.Details = newDetails;
                _context.CourseDetails.Add(newDetails);
            }

            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<CourseDetailsViewModel> GetCourseDetailsViewModelAsync(Guid courseId)
        {
            var courseDetails = await _context.CourseDetails
                .Include(cd => cd.CourseDetailsSkillLevels)
                    .ThenInclude(cdsl => cdsl.SkillLevel)
                .Include(cd => cd.CourseDetailsLanguages)
                    .ThenInclude(cdl => cdl.Language)
                .Include(cd => cd.CourseDetailsAssesments)
                    .ThenInclude(cda => cda.Assesment)
                .Include(cd => cd.Course)
                .FirstOrDefaultAsync(cd => cd.CourseId == courseId);

            if (courseDetails == null)
            {
                return null;
            }

            var courseDetailsViewModel = new CourseDetailsViewModel
            {
                Description = courseDetails.Course.Description,
                ImagePath = courseDetails.Course.ImagePath,
                ImageName = courseDetails.Course.ImageName,
                Start = courseDetails.Start,
                Duration = courseDetails.Duration,
                ClassDuration = courseDetails.ClassDuration,
                CourseFee = courseDetails.CourseFee,
                StudentCount = courseDetails.StudentCount,
                CourseDetailsSkills = courseDetails.CourseDetailsSkillLevels?
                    .Select(cdsl => cdsl.SkillLevel)
                    .Where(skillLevel => skillLevel != null)
                    .ToList(),
                CourseDetailsLanguages = courseDetails.CourseDetailsLanguages?
                    .Select(cdl => cdl.Language)
                    .ToList(),
                CourseDetailsAssesments = courseDetails.CourseDetailsAssesments?
                    .Select(cda => cda.Assesment)
                    .ToList()
            };

            return courseDetailsViewModel;
        }

    }
}
