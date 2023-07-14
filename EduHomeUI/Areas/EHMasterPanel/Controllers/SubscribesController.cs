using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.SubscriberViewModels;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    public class SubscribesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ISubscriberService _subscriberService;
        public SubscribesController(AppDbContext context,ISubscriberService subscriberService)
        {
            _context = context;
            _subscriberService = subscriberService;
        }
        public async Task<IActionResult> Index()
        {
            var subscribers = await _subscriberService.GetAllSubscribersAsync();

            var viewModel = new SubscriberIndexViewModel()
            {
                Subscribers = subscribers
            };
            return View(viewModel);
        }
    }
}
