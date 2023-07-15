using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels.AboutViewModels;
using EduHomeUI.ViewModels.HomeViewModels;
using EduHomeUI.ViewModels.SubscribeViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            AboutCompositeViewModel model = new AboutCompositeViewModel
            {
                AboutIndex = new AboutIndexViewModel
                {
                   Teachers = await _context.Teachers.ToListAsync(),
                    Notices = await _context.Notices.ToListAsync()
                },
                SubscriberCreate = new SubscriberCreateViewModel()
            };

            return View(model);
        }
    }
}
