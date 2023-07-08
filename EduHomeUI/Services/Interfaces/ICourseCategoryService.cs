using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseCategoryViewModels;

namespace EduHomeUI.Services.Interfaces
{
    public interface ICourseCategoryService
    {
        Task<bool> CreateCategoryAsync(CourseCategoryViewModel newCategory);
        Task<bool> DeleteCourseCategoryById(Guid categoryId);
        Task<List<CourseCategory>> GetAllCategoriesAsync();
        Task<bool>GetCategoryById(Guid categoryId);
        Task<CourseCategory> GetCategoryByIdCategory(Guid categoryId);
        Task<bool> UpdateCourseCategory(Guid categoryId, string newCategory);
    }
}
