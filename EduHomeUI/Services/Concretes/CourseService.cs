using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels;
using EduHomeUI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Services.Concretes
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;

        public CourseService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateCourseAsync(CourseViewModel courses)
        {
            if (courses is null) return false;

            var languageOption = await _context.Languages.FindAsync(courses.LanguageOptionId);
            if (languageOption is null) return false;

            var assesment = await _context.Assesments.FindAsync(courses.AssesmentId);
            if (assesment is null) return false;

            var skillLevel = await _context.SkillLevels.FindAsync(courses.SkillLevelId);
            if (skillLevel is null) return false;

            var courseCatagory = await _context.courseCategories.FindAsync(courses.CourseCategoryId);
            if (courseCatagory is null) return false;

            CourseDetails courseDetail = new()
            {
                AboutCourse = courses.AboutCourse,
                Certification = courses.Certification,
                Start = courses.Start,
                Duration = courses.Duration,
                CourseFee = courses.CourseFee,
                HowToApply = courses.HowToApply,
                ClassDuration = courses.ClassDuration,
                LanguageOption = languageOption,
                Skill = skillLevel,
                Assesment = assesment
            };

            await _context.courseDetails.AddAsync(courseDetail);
            await _context.SaveChangesAsync();



            Course course = new Course()
            {
                Name = courses.Name,
                Description = courses.Description,
                ImagePath = courses.ImagePath,
                ImageName = courses.ImageName,
                CourseCategoryId = courseCatagory.Id,
                CourseDetailsId = courseDetail.Id
            };

            await _context.courses.AddAsync(course);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
