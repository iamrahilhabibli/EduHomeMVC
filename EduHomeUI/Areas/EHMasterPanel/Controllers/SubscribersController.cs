using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.SubscriberViewModels;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    [Area("EHMasterPanel")]
    [Authorize(Roles = "Master,Admin")]
    public class SubscribersController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly AppDbContext _context;
        private readonly ISubscriberService _subscriberService;
        public SubscribersController(AppDbContext context,ISubscriberService subscriberService)
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
