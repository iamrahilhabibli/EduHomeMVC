using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels.CourseViewModels;
using EduHomeUI.ViewModels.HomeViewModels;
using EduHomeUI.ViewModels.SubscribeViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        public CourseController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            CourseCompositeViewModel model = new CourseCompositeViewModel
            {
                CourseIndexViewModel = new CourseIndexViewModel
                {
                    Courses = await _context.Courses.ToListAsync(),
                },
                SubscriberCreate = new SubscriberCreateViewModel()
            };

            return View(model);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            Course course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            CourseIndexViewModel courseVM = new()
            {
                Courses = new List<Course> { course },
                CourseDetails = await _context.CourseDetails.ToListAsync()
            };
            return View(courseVM);
        }
    }
}
