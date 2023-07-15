using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels;
using EduHomeUI.ViewModels.HomeViewModels;
using EduHomeUI.ViewModels.SubscribeViewModels;
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
            HomeCompositeViewModel model = new HomeCompositeViewModel
            {
                HomeIndex = new HomeIndexViewModel
                {
                    //Notices = await _context.Notices.ToListAsync(),
                    Courses = await _context.Courses.ToListAsync(),
                    Events = await _context.Events.ToListAsync(),
                    Sliders = await _context.Sliders.ToListAsync(),
                    Blogs = await _context.Blogs.ToListAsync(),
                },
                SubscriberCreate = new SubscriberCreateViewModel()
            };

            return View(model);
        }
        public IActionResult TestException()
        {
            throw new Exception("This is a test exception.");
        }

    }
}
