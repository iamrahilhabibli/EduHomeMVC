using System;
using System.IO;
using System.Threading.Tasks;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Services.Interfaces;
using EduHomeUI.ViewModels.SubscribeViewModels;
using EduHomeUI.ViewModels.WelcomeViewModel;
using EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;

namespace EduHomeUI.Controllers
{
    public class SubscribeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailSenderService _emailSenderService;
        private readonly ISubscriberService _subscriberService;
        
        public SubscribeController(AppDbContext context,
                                   UserManager<AppUser> userManager,
                                   IEmailSenderService emailSenderService,
                                   ISubscriberService subscriberService)
        {
            _context = context;
            _userManager = userManager;
            _emailSenderService = emailSenderService;
            _subscriberService = subscriberService;
        
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
            bool isSubscribed = await _subscriberService.IsUserSubscribed(subVm.Email);
            if (isSubscribed)
            {
                TempData["Error"] = "You are already subscribed!";
                return RedirectToAction("Index", "Contact");
            }

            await _subscriberService.AddSubscriberAsync(subVm.Email, user.Id);

            TempData["Success"] = "You have successfully subscribed!";

            var model = new WelcomeViewModel
            {
                UserName = user.UserName
            };

            var viewPath = "~/Views/EmailTemplates/WelcomeTemplate.cshtml";
            var emailContent = await ViewRenderer.RenderViewToStringAsync(this, viewPath, model);

            var message = new Message(new string[] { user.Email }, "Welcome to EduHome", emailContent);
            _emailSenderService.SendEmail(message);

            return RedirectToAction("Index", "Contact");
        }
    }
}
