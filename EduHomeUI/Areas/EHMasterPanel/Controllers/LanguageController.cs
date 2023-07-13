using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.LanguageViewModels;
using EduHomeUI.Services.Concretes;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
	[Area("EHMasterPanel")]
	[Authorize]
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
			var languageList = await _languageService.GetAllLanguages();

			var viewModel = new LanguageIndexViewModel()
			{
				Languages = languageList
			};
			return View(viewModel);
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
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(Guid id)
		{
			if (!await _languageService.GetLanguageById(id)) return NotFound();

			var language = await _languageService.GetLanguageByIdLanguage(id);

			var viewModel = new LanguageViewModel()
			{
				LanguageOption = language.LanguageOption
			};
			return View(viewModel);
		}
        [HttpPost]
        [ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteLanguage(Guid id)
        {
			//bool isDeleted = await _languageService.DeleteLanguageById(id);

			//if (!isDeleted) return NotFound();

			//TempData["Success"] = "Language Deleted Successfully";
			//return RedirectToAction(nameof(Index));

			Language newLanguage = await _context.Languages.FindAsync(id);
			if (newLanguage == null) { return NotFound(); }
			_context.Languages.Remove(newLanguage);
			_context.SaveChanges();
            TempData["Success"] = "Language Deleted Successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
