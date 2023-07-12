using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels.EventViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        public EventController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            EventIndexViewModel viewModel = new EventIndexViewModel()
            {
                Events = await _context.Events.ToListAsync()
            };
            return View(viewModel);
        }
    }
}
