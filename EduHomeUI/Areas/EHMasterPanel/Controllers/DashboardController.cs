using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    [Authorize]
    [Area("EHMasterPanel")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
                _context = context;
        }
        public IActionResult Index()
        {
            string firstName = string.Empty;
            if (User.Identity.IsAuthenticated)
            {
                string username = User.Identity.Name;
                AppUser user = _context.Users.FirstOrDefault(u => u.UserName == username);
                if (user != null)
                {
                    firstName = user.FirstName;
                }
            }
            ViewBag.FirstName = firstName;
            return View();
        }

    }
}
