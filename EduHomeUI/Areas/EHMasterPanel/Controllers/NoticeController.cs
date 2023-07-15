using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.LanguageViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.NoticeViewModels.cs;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    [Area("EHMasterPanel")]
    [Authorize(Roles = "Master,Admin")]
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
        public async Task<IActionResult> Create(NoticeCreateViewModel noticeVm)
        {
            if (!ModelState.IsValid) return NotFound();
            if (!await _noticeService.CreateNoticeAsync(noticeVm)) return BadRequest();
            TempData["Success"] = "Notice Created Successfully!";
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await _noticeService.GetNoticeById(id)) return NotFound();

            var notice = await _noticeService.GetNoticeByIdNotice(id);

            var viewModel = new NoticeCreateViewModel()
            {
                Description = notice.Description
            };
            return View(viewModel);
        }
        [HttpPost]
        [ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteNotice(Guid id)
        {
            bool isDeleted = await _noticeService.DeleteNoticeById(id);

            if (!isDeleted) return NotFound();

            TempData["Success"] = "Notice Deleted Successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
