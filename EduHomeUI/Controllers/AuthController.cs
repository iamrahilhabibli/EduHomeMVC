using EduHome.Core.Entities;
using EduHomeUI.ViewModels.UsersViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

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
                Email = userRegVm.EmailAddress
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
            if (user is null) { ModelState.AddModelError("", "Invalid login credentials"); }

            return RedirectToAction("Index", "Home");
        }
    }
}
