using EduHome.Core.Entities;
using EduHomeUI.ViewModels.UsersViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EmailService;
using Message = EmailService.Message;
using GoogleReCaptcha.V3.Interface;
using System.Security.Claims;
using EduHome.Core.Utilities;

namespace EduHomeUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailSenderService _emailSenderService;
        private readonly ICaptchaValidator _captchaValidator;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly GoogleCaptchaService _googleCaptchaService;

        public AuthController(UserManager<AppUser> userManager,
                              SignInManager<AppUser> signInManager,
                              IEmailSenderService emailSenderService,
                              ICaptchaValidator captchaValidator,
                              RoleManager<IdentityRole> roleManager,
                              GoogleCaptchaService googleCaptchaService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSenderService = emailSenderService;
            _captchaValidator = captchaValidator;
            _roleManager = roleManager;
            _googleCaptchaService = googleCaptchaService;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterViewModel userRegVm)
        {
            //var googleReCaptcha = _googleCaptchaService.VerifyCaptcha();

            if (!ModelState.IsValid)
            {
                return View(userRegVm);
            }

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

            var emailContent = $"Click the following link to confirm your account: <a href=\"{confirmationLink}\">Confirm Account</a>";

            var message = new Message(new string[] { user.Email }, "Confirmation email link", emailContent);
            _emailSenderService.SendEmail(message); // ASYNC

            await _userManager.AddToRoleAsync(user, "Visitor");

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
            var resetUrl = Url.Action(nameof(ResetPassword), "Auth", new { token, email = user.Email }, Request.Scheme);

            var emailContent = $"Click the following link to reset your password: <a href=\"{resetUrl}\">Reset Password</a>";

            var message = new Message(new string[] { user.Email }, "Reset Password Token", emailContent);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Auth", new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }
        [HttpGet]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (signInResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            if (signInResult.IsLockedOut)
            {
                return RedirectToAction(nameof(ForgotPassword));
            }
            else
            {
                ViewData["ReturnUrl"] = returnUrl;
                ViewData["Provider"] = info.LoginProvider;
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                return View("ExternalLogin", new EduHome.Core.Entities.ExternalLoginModel { Email = email });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(EduHome.Core.Entities.ExternalLoginModel model, string returnUrl = null)
        {
            if (!ModelState.IsValid)
                return View(model);

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
                return View(nameof(Error));

            var user = await _userManager.FindByEmailAsync(model.Email);
            IdentityResult result;

            if (user != null)
            {
                result = await _userManager.AddLoginAsync(user, info);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                model.Principal = info.Principal;
                user = new AppUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = "", 
                    LastName = "",
                    DateOfBirth = DateTime.MinValue
                };

                result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }

            return View(nameof(ExternalLogin), model);
        }
        #region Create Role
        //[AllowAnonymous]
        //public async Task CreateRole()
        //{
        //    foreach (var role in Enum.GetValues(typeof(UserRole.Roles)))
        //    {
        //        bool exists = await _roleManager.RoleExistsAsync(role.ToString());
        //        if (!exists)
        //        {
        //            await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
        //        }
        //    }
        //}
        #endregion
    }
}
