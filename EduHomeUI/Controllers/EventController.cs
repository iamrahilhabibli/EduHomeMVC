using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.EventViewModels;
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
            ViewModels.EventViewModels.EventIndexViewModel viewModel = new()
            {
                Events = await _context.Events.ToListAsync()
            };
            return View(viewModel);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var viewModel = new ViewModels.EventViewModels.EventIndexViewModel();

            var @event = await _context.Events
                .Include(e => e.EventSpeakers)
                .ThenInclude(es => es.Speaker)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (@event == null)
            {
                return NotFound();
            }

            viewModel.Events = new List<Event> { @event };
            viewModel.EventSpeakers = @event.EventSpeakers;

            return View(viewModel);
        }

    }
}
