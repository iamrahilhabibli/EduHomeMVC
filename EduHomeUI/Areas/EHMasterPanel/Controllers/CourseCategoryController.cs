using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseCategoryViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels;
using EduHomeUI.Services.Concretes;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    [Area("EHMasterPanel")]
    [Authorize(Roles = "Master,Admin")]
    public class CourseCategoryController : Controller
	{
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;
		private readonly ICourseCategoryService _categoryService;
		public CourseCategoryController(AppDbContext context, IMapper mapper, ICourseCategoryService categoryService)
		{
			_context = context;
			_mapper = mapper;
            _categoryService = categoryService;
        }
		public async Task<IActionResult> Index()
		{
            var categoriesList = await _categoryService.GetAllCategoriesAsync();

            var viewModel = new CourseCategoryIndexViewModel
            {
                Category = categoriesList
            };

            return View(viewModel);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CourseCategoryViewModel viewCategory)
		{
			if (!ModelState.IsValid) return BadRequest();
			if (!await _categoryService.CreateCategoryAsync(viewCategory)) return BadRequest();
			TempData["Success"] = "Category Created Successfully!";
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(Guid id)
		{
            if (!await _categoryService.GetCategoryById(id))
            {
                return NotFound();
            }
            var category =await _categoryService.GetCategoryByIdCategory(id);
            var viewModel = new CourseCategoryDeleteViewModel()
            {
                Category = category.Category
            };
            return View(viewModel);
		}
        [HttpPost]
        [ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            bool isDeleted = await _categoryService.DeleteCourseCategoryById(id);

            if (!isDeleted) return NotFound();

            TempData["Success"] = "Category Deleted Successfully";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(Guid Id)
        {
            CourseCategory category = _context.CourseCategories.Find(Id);
            if (category == null)
            {
                return NotFound();
            }

            CourseCategoryViewModel viewModel = new()
            {
                Category = category.Category,
                DateModified = category.DateModified
            };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Guid id, CourseCategoryViewModel newCategory)
        {
            if (!ModelState.IsValid) return View(newCategory);
            bool isUpdated = await _categoryService.UpdateCourseCategory(id, newCategory.Category);

            if (!isUpdated)return NotFound();

            TempData["Success"] = "Category Updated Successfully";
            return RedirectToAction(nameof(Index));
        }


    }
}
