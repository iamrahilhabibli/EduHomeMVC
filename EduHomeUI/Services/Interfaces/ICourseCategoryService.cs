using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels;

namespace EduHomeUI.Services.Interfaces
{
    public interface ICourseCategoryService
    {
        Task<bool> CreateCategoryAsync(CourseCategoryViewModel newCategory);
    }
}
