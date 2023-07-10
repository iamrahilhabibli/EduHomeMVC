using AutoMapper;
using EduHome.Core.Entities;
using EduHomeUI.ViewModels.UsersViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using EmailService;

namespace EduHomeUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailSenderService _emailSenderService;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailSenderService emailSenderService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSenderService = emailSenderService;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterViewModel userRegVm)
        {
            if (!ModelState.IsValid) return View(userRegVm);
            AppUser user = new()
            {
                FirstName = userRegVm.FirstName,
                LastName = userRegVm.LastName,
                UserName = userRegVm.UserName,
                Email = userRegVm.EmailAddress,
                DateOfBirth = userRegVm.DateOfBirth
            };
            IdentityResult result = await _userManager.CreateAsync(user, userRegVm.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(userRegVm);
            }
            return Ok();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userLogVm)
        {
            if (!ModelState.IsValid) return View(userLogVm);
            AppUser user = await _userManager.FindByEmailAsync(userLogVm.EmailAddress);
            if (user is null)
            {
                ModelState.AddModelError("", "Invalid login credentials");
            }
            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, userLogVm.Password, userLogVm.RememberMe, true);
            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "Your Account is Temporarily Locked - Try Again Later");
            }
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Invalid login credentials");
            }
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPassword forgotPasswordModel)
        {
            if (!ModelState.IsValid)
            {
                return View(forgotPasswordModel);
            }
            var user = await _userManager.FindByEmailAsync(forgotPasswordModel.Email);
            if (user is null)
            {
                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callback = Url.Action(nameof(ResetPassword), "Account", new { token, email = user.Email }, Request.Scheme);
            var message = new EmailService.Message(new string[] { user.Email }, "Reset Password Token", callback);
            _emailSenderService.SendEmail(message);
            return RedirectToAction(nameof(ForgotPasswordConfirmation));
        }
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new EduHome.Core.Entities.ResetPasswordModel { Token = token, Email = email };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>ResetPassword(EduHome.Core.Entities.ResetPasswordModel model)
        {
            return View();
        }
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
    }
}
