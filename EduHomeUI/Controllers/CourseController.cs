using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels.CourseViewModels;
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
            CourseIndexViewModel viewModel = new CourseIndexViewModel()
            {
                Courses = await _context.Courses.ToListAsync()
            };
            return View(viewModel);
        }
    }
}
