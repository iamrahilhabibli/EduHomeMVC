using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.AssesmentViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.BlogViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseCategoryViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.SettingViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.TeacherViewModels;
using EduHomeUI.Services.Concretes;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    [Area("EHMasterPanel")]
    [Authorize]
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ISettingService _settingService;
        public SettingController(AppDbContext context, ISettingService settingService)
        {
            _context = context;
            _settingService = settingService;
        }
        public async Task<IActionResult> Index()
        {
            var settingList = await _settingService.GetAllSettingsAsync();

            var viewModel = new SettingIndexViewModel
            {
                Settings = settingList
            };
            return View(viewModel);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(SettingCreateViewModel settingVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _settingService.CreateSettingAsync(settingVm)) return BadRequest();
            TempData["Success"] = "Setting Created Successfully!";
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await _settingService.GetSettingById(id))
            {
                return NotFound();
            }

            var setting = await _settingService.GetSettingByIdSetting(id);

            var viewModel = new SettingCreateViewModel
            {
                Key = setting.Key,
                Value = setting.Value
            };

            return View(viewModel);
        }
        [HttpPost]
        [ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteSetting(Guid id)
        {
            bool isDeleted = await _settingService.DeleteSettingById(id);

        if (!isDeleted) return NotFound();

            TempData["Success"] = "Setting Deleted Successfully";
            return RedirectToAction(nameof(Index));
        }

		public IActionResult Update(Guid Id)
		{
			Setting setting = _context.Settings.Find(Id);
			if (setting == null)
			{
				return NotFound();
			}

			SettingCreateViewModel viewModel = new()
			{
				Key = setting.Key,
				Value = setting.Value
			};
			return View(viewModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(Guid id, SettingCreateViewModel setting)
		{
			if (!ModelState.IsValid)
			{
				return View(setting);
			}

			bool isUpdated = await _settingService.UpdateSetting(id, setting);

			if (!isUpdated)
			{
				return NotFound();
			}

			TempData["Success"] = "Setting Updated Successfully";

			return RedirectToAction(nameof(Index));
		}
	}
}
