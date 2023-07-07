using EduHome.DataAccess.Contexts;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    public class CourseDetailsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICourseDetailsService _courseDetailsService;

        public CourseDetailsController(AppDbContext context, ICourseDetailsService courseDetailsService)
        {
            _context = context;
            _courseDetailsService = courseDetailsService;
        }
        public async Task<IActionResult> Index()
        {
            var courseDetails = await _courseDetailsService.GetAllCourseDetailsAsync();
            return View(courseDetails);
        }
    }
}
