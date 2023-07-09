using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.EventViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.SpeakerViewModels;
using EduHomeUI.Services.Concretes;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    [Area("EHMasterPanel")]
    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IEventService _eventService;
        public EventController(AppDbContext context, IMapper mapper, IEventService eventService)
        {
            _context = context;
            _mapper = mapper;   
            _eventService = eventService;
        }
        public async Task<IActionResult> Index()
        {
            var eventsList = await _eventService.GetAllEventsAsync();

            var viewModel = new EventIndexViewModel
            {
                Events = eventsList
            };

            return View(viewModel);
        }
        public async Task<IActionResult> Create()
        {
            List<Speaker> speakers = await _context.Speakers.ToListAsync();

            EventCreateViewModel viewModel = new EventCreateViewModel
            {
                Speakers = speakers
            };

            return View(viewModel);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(EventCreateViewModel eventVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _eventService.CreateEventAsync(eventVm)) return BadRequest();
            TempData["Success"] = "Event Created Successfully!";
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await _eventService.GetEventById(id)) return NotFound();

            var newEvent = await _eventService.GetEventByIdEvent(id);

            var viewModel = new EventDeleteViewModel()
            {
               Title = newEvent.Title,
               Venue = newEvent.Venue,
               ImagePath = newEvent.ImagePath,
               Date = newEvent.Date
            };
            return View(viewModel);
        }
        [HttpPost]
        [ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            bool isDeleted = await _eventService.DeleteEventById(id);

            if (!isDeleted) return NotFound();

            TempData["Success"] = "Event Deleted Successfully";
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(Guid eventId)
        {
            var eventDetailsViewModel = await _eventService.GetEventDetailsViewModelAsync(eventId);

            if (eventDetailsViewModel == null)
            {
                return NotFound();
            }

            return View(eventDetailsViewModel);
        }

    }
}
