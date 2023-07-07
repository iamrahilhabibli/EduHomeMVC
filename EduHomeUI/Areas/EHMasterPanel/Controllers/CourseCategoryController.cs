using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    [Area("EHMasterPanel")]
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
			return View(await _context.courseCategories.ToListAsync());
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

		public IActionResult Delete(int id)
		{
			CourseCategory category = _context.courseCategories.Find(id);
			if (category == null) { return NotFound(); }
			return View(category);
		}
		[HttpPost]
		[ActionName("Delete")]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> DeleteCategory(int Id)
		{
			CourseCategory category = await _context.courseCategories.FindAsync(Id);
			if (category == null)
			{
				return NotFound();
			}
			category.IsDeleted = true;
			await _context.SaveChangesAsync();
			TempData["Success"] = "Category Deleted Successfully";

			return RedirectToAction(nameof(Index));
		}

		public IActionResult Update(int Id)
		{
			CourseCategory category = _context.courseCategories.Find(Id);
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
		public IActionResult Update(int id, CourseCategoryViewModel newCategory)
		{
			if (!ModelState.IsValid)
			{
				return View(newCategory);
			}

			CourseCategory category = _context.courseCategories.Find(id);
			if (category == null)
			{
				return NotFound();
			}

			category.Category = newCategory.Category;
			category.DateModified = DateTime.Now;
			_context.SaveChanges();

			TempData["Success"] = "Category Updated Successfully";
			return RedirectToAction(nameof(Index));
		}

	}
}
