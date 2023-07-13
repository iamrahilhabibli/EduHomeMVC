using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.TeacherViewModels;
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
    }
}
