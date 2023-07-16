using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;

namespace EduHomeUI.Controllers
{
    [Authorize]
    public class BuyNowController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly AppDbContext _context;
        private readonly ICourseService _courseService;
        private readonly UserManager<AppUser> _userManager;
        public BuyNowController(AppDbContext context, ICourseService courseService,UserManager<AppUser> userManager)
        {
            _context = context;
            _courseService = courseService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Auth");
            }
            var coursesList = await _courseService.GetAllCourseAsync();

            var viewModel = new CourseIndexViewModel
            {
                courses = coursesList
            };

            return View(viewModel);
        }
    }
}
