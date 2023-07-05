using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
