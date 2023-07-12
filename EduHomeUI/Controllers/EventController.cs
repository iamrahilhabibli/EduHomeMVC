using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
