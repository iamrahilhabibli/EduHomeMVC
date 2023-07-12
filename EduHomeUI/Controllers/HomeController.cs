using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels.HomeViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeIndexViewModel model = new HomeIndexViewModel()
            {
                Notices = await _context.Notices.ToListAsync(),
                Courses = await _context.Courses.ToListAsync(),
            };
            return View(model);
        }
    }
}
