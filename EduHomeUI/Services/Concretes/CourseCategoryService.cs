using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels;
using EduHomeUI.Services.Interfaces;

namespace EduHomeUI.Services.Concretes
{
    public class CourseCategoryService:ICourseCategoryService
    {
        private readonly AppDbContext _context;
        public CourseCategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCategoryAsync(CourseCategoryViewModel newCategory)
        {
            if (newCategory == null) return false;

            CourseCategory newCourseCategory = new()
            {
                Category = newCategory.Category,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };
            await _context.courseCategories.AddAsync(newCourseCategory);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
