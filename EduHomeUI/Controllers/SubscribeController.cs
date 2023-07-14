using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels.SubscribeViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly AppDbContext _context;
        public SubscribeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create(SubscriberCreateViewModel subVm)
        {

            Subscribers newSub = new()
            {
                Email = subVm.Email
            };
           await _context.Subscribers.AddAsync(newSub);
           await _context.SaveChangesAsync();
            TempData["Success"] = "You have successfully subscribed!";
            return RedirectToAction("Index", "Contact");
        }
    }
}
