using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.AppUserViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    [Area("EHMasterPanel")]
    public class AppUserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public AppUserController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;

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
        public async Task<IActionResult> Update(string id) 
        {
            AppUser user = await _context.Users.FindAsync(id);
            if (user is null)
            {
                return NotFound();
            }
            AppUserUpdateViewModel viewModel = new()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Guid id)
        {
            AppUser user = await _context.Users.FindAsync(id.ToString());
            if (user is null)
            {
                return NotFound();
            }

            var roleManager = HttpContext.RequestServices.GetRequiredService<RoleManager<IdentityRole>>();
            var adminRole = await roleManager.FindByNameAsync("Admin");

            if (adminRole != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRoles);
                await _userManager.AddToRoleAsync(user, adminRole.Name);
            }
            else
            {
                TempData["Error"] = "Role does not Exist";
            }
            TempData["Success"] = "User Role Changed To Admin Successfully";
            return RedirectToAction(nameof(Index));
        }

    }
}
