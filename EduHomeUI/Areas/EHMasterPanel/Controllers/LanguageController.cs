using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.LanguageViewModels;
using EduHomeUI.Services.Concretes;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
	[Area("EHMasterPanel")]
	public class LanguageController : Controller
	{
		private readonly AppDbContext _context;
		private readonly ILanguageService _languageService;

        public LanguageController(AppDbContext context,ILanguageService languageService)
        {
			_context = context;
			_languageService = languageService;
        }
        public async Task<IActionResult> Index()
		{
			return View();
		}

		public async Task<IActionResult> Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(LanguageViewModel languageVm)
		{
			if (!ModelState.IsValid)return NotFound();
			if (!await _languageService.CreateLanguageAsync(languageVm)) return BadRequest();
			TempData["Success"] = "Language Created Successfully!";
			return RedirectToAction("Index","Dashboard");
		}
	}
}
