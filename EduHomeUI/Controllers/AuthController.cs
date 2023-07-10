using EduHome.Core.Entities;
using EduHomeUI.ViewModels.UsersViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public AuthController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
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
    }
}
