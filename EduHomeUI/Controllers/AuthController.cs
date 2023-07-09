using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
