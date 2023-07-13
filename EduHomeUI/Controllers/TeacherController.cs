using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels.TeacherViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;

        public TeacherController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            TeacherIndexViewModel model = new TeacherIndexViewModel()
            {
                Teachers = await _context.Teachers.ToListAsync()
            };
            return View(model);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            Teacher teacher = await _context.Teachers.FindAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            TeacherIndexViewModel teacherVM = new()
            {
                Teachers = new List<Teacher> { teacher },
                Details = await _context.TeacherDetails.ToListAsync()
            };
            return View(teacherVM);
        }
    }
}
