using EduHomeUI.ViewModels.UsersViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserRegisterViewModel userRegVm)
        {
            if (!ModelState.IsValid) return View(userRegVm);
            return View();
        }
    }
}
