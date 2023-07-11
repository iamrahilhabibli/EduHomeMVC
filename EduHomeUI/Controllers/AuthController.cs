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
using Message = EmailService.Message;
using GoogleReCaptcha.V3.Interface;

namespace EduHomeUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailSenderService _emailSenderService;
        private readonly ICaptchaValidator _captchaValidator;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailSenderService emailSenderService, ICaptchaValidator captchaValidator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSenderService = emailSenderService;
            _captchaValidator = captchaValidator;
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
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Auth", new { token, email = user.Email }, Request.Scheme);
            var message = new Message(new string[] { user.Email }, "Confirmation email link", confirmationLink);
            _emailSenderService.SendEmail(message); // ASYNC
            //await _userManager.AddToRoleAsync(user, "Visitor");
            return RedirectToAction(nameof(SuccessRegistration));
        }
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return View("Error");
            }
            var result = await _userManager.ConfirmEmailAsync(user, token);
            return View(result.Succeeded ? nameof(ConfirmEmail) : "Error");
        }
        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SuccessRegistration()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
		public async Task<IActionResult> Login(UserLoginViewModel userLogVm)
		{
			if (!ModelState.IsValid)
			{
				return View(userLogVm);
			}

			AppUser user = await _userManager.FindByEmailAsync(userLogVm.EmailAddress);

			if (user is null)
			{
				ModelState.AddModelError("", "Invalid login credentials");
				return View(userLogVm);
			}

			if (!await _userManager.IsEmailConfirmedAsync(user))
			{
				ModelState.AddModelError("", "Please confirm your email address to log in.");
				return View(userLogVm);
			}

			Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, userLogVm.Password, userLogVm.RememberMe, true);

			if (signInResult.IsLockedOut)
			{
				ModelState.AddModelError("", "Your account is temporarily locked. Please try again later.");
				return View(userLogVm);
			}

			if (!signInResult.Succeeded)
			{
				ModelState.AddModelError("", "Invalid login credentials");
				return View(userLogVm);
			}

			return RedirectToAction("Index", "Home");
		}


		[AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
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
            var callback = Url.Action(nameof(ResetPassword), "Auth", new { token, email = user.Email }, Request.Scheme);
            var message = new EmailService.Message(new string[] { user.Email }, "Reset Password Token", callback);
            _emailSenderService.SendEmail(message);
            return RedirectToAction(nameof(ForgotPasswordConfirmation));
        }
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new EduHome.Core.Entities.ResetPasswordModel { Token = token, Email = email };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>ResetPassword(EduHome.Core.Entities.ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }
            var resetPassResult = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (!resetPassResult.Succeeded) 
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View();
            }
            return RedirectToAction(nameof(ResetPasswordConfirmation));
        }
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
    }
}
