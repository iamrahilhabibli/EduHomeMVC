using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.AppUserViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    [Area("EHMasterPanel")]
    public class AppUserController : Controller
    {
        private readonly AppDbContext _context;
        public AppUserController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = new AppUserIndexViewModel
            {
                AppUsers = await _context.Users.ToListAsync()
            };

            var userRoles = await _context.UserRoles.ToListAsync();
            var roles = await _context.Roles.ToListAsync();

            ViewBag.UserRoles = userRoles;
            ViewBag.Roles = roles;

            return View(model);
        }

    }
}
