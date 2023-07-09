using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
