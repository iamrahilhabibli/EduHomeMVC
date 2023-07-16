using EduHome.Core.Entities;
using EduHomeUI.ViewModels.ProfileViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Controllers
{
    [Authorize]
    public class MyProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public MyProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var viewModel = new MyProfileViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
            };
            return View(viewModel);
        }
    }
}
