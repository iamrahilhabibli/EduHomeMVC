using AutoMapper;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.EventViewModels;
using EduHomeUI.Services.Concretes;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
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
    }
}
