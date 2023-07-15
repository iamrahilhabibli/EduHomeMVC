using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.AppUserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    [Area("EHMasterPanel")]
    [Authorize(Roles = "Master,Admin")]
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
        public async Task<IActionResult> Visitor(string id)
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
        public async Task<IActionResult> Visitor(Guid id)
        {
            AppUser user = await _context.Users.FindAsync(id.ToString());
            if (user is null)
            {
                return NotFound();
            }

            var roleManager = HttpContext.RequestServices.GetRequiredService<RoleManager<IdentityRole>>();
            var visitorRole = await roleManager.FindByNameAsync("Visitor");

            if (visitorRole != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRoles);
                await _userManager.AddToRoleAsync(user, visitorRole.Name);
            }
            else
            {
                TempData["Error"] = "Role does not Exist";
            }
            TempData["Success"] = "User Role Changed To Visitor Successfully";
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Master(string id)
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
        public async Task<IActionResult> Master(Guid id)
        {
            AppUser user = await _context.Users.FindAsync(id.ToString());
            if (user is null)
            {
                return NotFound();
            }

            var roleManager = HttpContext.RequestServices.GetRequiredService<RoleManager<IdentityRole>>();
            var masterRole = await roleManager.FindByNameAsync("Master");

            if (masterRole != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRoles);
                await _userManager.AddToRoleAsync(user, masterRole.Name);
            }
            else
            {
                TempData["Error"] = "Role does not Exist";
            }
            TempData["Success"] = "User Role Changed To Master Successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
