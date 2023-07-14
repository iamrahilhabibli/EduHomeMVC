using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels.SubscribeViewModels;
using EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailSenderService _emailSenderService;
        public SubscribeController(AppDbContext context,
                                   UserManager<AppUser> userManager,
                                   IEmailSenderService emailSenderService)
        {
            _context = context;
            _userManager = userManager;
            _emailSenderService = emailSenderService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SubscriberCreateViewModel subVm)
        {
            if (!User.Identity.IsAuthenticated)
            {
                TempData["Error"] = "You need to sign up to subscribe or login if you are already signed up!";
                return RedirectToAction("Register", "Auth");
            }

            var user = await _userManager.FindByEmailAsync(subVm.Email);
            if (user == null)
            {
                TempData["Error"] = "The provided email is not registered.";
                return RedirectToAction("Index", "Contact");
            }

            Subscribers newSub = new Subscribers
            {
                Email = subVm.Email,
                UserId = Guid.Parse(user.Id)
            };

            await _context.Subscribers.AddAsync(newSub);
            await _context.SaveChangesAsync();

            TempData["Success"] = "You have successfully subscribed!";
            TempData["Email"] = subVm.Email;

            var emailContent = $"Welcome to Edu Home ";

            var message = new Message(new string[] { user.Email }, "Edu Home Weekly Subscription", emailContent);
            _emailSenderService.SendEmail(message); 

            return RedirectToAction("Index", "Contact");
        }


    }
}
