using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels.AboutViewModels;
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
            AboutIndexViewModel model = new()
            {
                Teachers = await _context.Teachers.ToListAsync(),
                Notices = await _context.Notices.ToListAsync()
            };
            return View(model);
        }
    }
}
