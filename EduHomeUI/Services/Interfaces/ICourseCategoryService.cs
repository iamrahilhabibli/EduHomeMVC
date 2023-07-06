using EduHomeUI.Areas.EHMasterPanel.ViewModels;

namespace EduHomeUI.Services.Interfaces
{
    public interface ICourseCategoryService
    {
        Task<bool> CreateCategoryAsync(CourseCategoryViewModel newCategory);
    }
}
