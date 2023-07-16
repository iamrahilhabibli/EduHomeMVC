using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;

namespace EduHomeUI.Controllers
{
    [Authorize]
    public class BuyNowController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly AppDbContext _context;
        private readonly ICourseService _courseService;
        public BuyNowController(AppDbContext context, ICourseService courseService)
        {
            _context = context;
            _courseService = courseService;
        }
        public async Task<IActionResult> Index()
        {
            var coursesList = await _courseService.GetAllCourseAsync();

            var viewModel = new CourseIndexViewModel
            {
                courses = coursesList
            };

            return View(viewModel);
        }
    }
}
