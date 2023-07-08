using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseCategoryViewModels;

namespace EduHomeUI.Services.Interfaces
{
    public interface ICourseCategoryService
    {
        Task<bool> CreateCategoryAsync(CourseCategoryViewModel newCategory);
        Task<bool> DeleteCourseCategoryById(Guid categoryId);
    }
}
