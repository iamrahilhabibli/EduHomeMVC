using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
