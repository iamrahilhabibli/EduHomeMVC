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

        public Task<bool> CreateCategoryAsync(CourseCategoryViewModel newCategory)
        {
            throw new NotImplementedException();
        }
    }
}
