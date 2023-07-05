using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
	[Area("EHMasterPanel")]
	public class CourseCategoryController : Controller
	{
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;
		public CourseCategoryController(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
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
			if (!ModelState.IsValid) { return View(); }

			CourseCategory newCategory = new()
			{
				Category = viewCategory.Category,
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now
			};

			await _context.courseCategories.AddAsync(newCategory);
			await _context.SaveChangesAsync();
			TempData["Success"] = "Category Created Successfully!";
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Delete(int id)
		{
			CourseCategory category = _context.courseCategories.Find(id);
			if (category == null) { return NotFound(); }
			return View(category);
		}
	}
}
