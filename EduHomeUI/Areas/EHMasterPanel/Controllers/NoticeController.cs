using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.LanguageViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.NoticeViewModels.cs;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    [Area("EHMasterPanel")]
    public class NoticeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly INoticeService _noticeService;

        public NoticeController(AppDbContext context, INoticeService noticeService)
        {
            _context = context;
            _noticeService = noticeService;
        }
        public async  Task<IActionResult> Index()
        {
            var noticeList = await _noticeService.GetAllNotices();

            var viewModel = new NoticeIndexViewModel()
            {
                Notices = noticeList
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
            if (!ModelState.IsValid) return NotFound();
            if (!await _languageService.CreateLanguageAsync(languageVm)) return BadRequest();
            TempData["Success"] = "Language Created Successfully!";
            return RedirectToAction(nameof(Index));
        }

    }
}
