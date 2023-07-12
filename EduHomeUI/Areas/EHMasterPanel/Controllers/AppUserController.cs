using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    public class AppUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
