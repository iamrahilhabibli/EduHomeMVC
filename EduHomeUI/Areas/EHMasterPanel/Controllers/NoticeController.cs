using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.NoticeViewModels.cs;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
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
    }
}
