using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
