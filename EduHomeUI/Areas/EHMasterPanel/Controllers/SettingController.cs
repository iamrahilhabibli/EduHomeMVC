using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.AssesmentViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.SettingViewModels;
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
        public async Task <IActionResult> Index()
        {
            var settingList = await _settingService.GetAllSettingsAsync();

            var viewModel = new SettingIndexViewModel
            {
                Settings = settingList
            };
            return View(viewModel);
        }
    }
}
