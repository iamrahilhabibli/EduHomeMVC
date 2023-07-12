using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    [Area("EHMasterPanel")]
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICourseService _courseService;
        public CourseController(AppDbContext context, IMapper mapper, ICourseService courseService)
        {
            _context = context;
            _mapper = mapper;
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
        public async Task<IActionResult> Details(Guid courseId)
        {
            var courseDetailsViewModel = await _courseService.GetCourseDetailsViewModelAsync(courseId);

            if (courseDetailsViewModel == null)
            {
                return NotFound();
            }

            var course = await _courseService.GetCourseByIdCourse(courseId);
            if (course == null)
            {
                return NotFound();
            }

            ViewBag.CourseName = course.Name;

            return View(courseDetailsViewModel);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.CourseCategories.ToListAsync();
            ViewBag.Assesments = await _context.Assesments.ToListAsync();
            ViewBag.Languages = await _context.Languages.ToListAsync();
            ViewBag.SkillLevels = await _context.SkillLevels.ToListAsync();
            return View();

        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CourseViewModel courses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _courseService.CreateCourseAsync(courses)) return BadRequest();
            TempData["Success"] = "Course Created Successfully!";
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await _courseService.GetCourseById(id))
            {
                return NotFound();
            }

            var course = await _courseService.GetCourseByIdCourse(id);

            var viewModel = new CourseDeleteViewModel
            {
                Name = course.Name,
                Description = course.Description,
            };

            return View(viewModel);
        }


        [HttpPost]
        [ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            if (!await _courseService.GetCourseById(id))
            {
                return NotFound();
            }

            var courseDetailExists = await _courseService.GetCourseDetailById(id);
            if (courseDetailExists)
            {
                await _courseService.UpdateCourseDetailIsDeleted(id, true);
            }

            var deleted = await _courseService.UpdateCourseIsDeleted(id, true);
            if (deleted)
            {
                TempData["Success"] = "Course Deleted Successfully";
            }
            else
            {
                TempData["Error"] = "Failed to delete the course.";
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var course = await _courseService.GetCourseByIdCourse(id);
            if (course == null)
            {
                return NotFound();
            }

            var viewModelCourse = await _courseService.MapCourseVM(course);

            ViewBag.LanguageOptions = await _context.Languages.ToListAsync();
            ViewBag.AssessmentOptions = await _context.Assesments.ToListAsync();
            ViewBag.SkillLevelOptions = await _context.SkillLevels.ToListAsync();
            ViewBag.CourseCategories = await _context.CourseCategories.ToListAsync();

            return View(viewModelCourse);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Guid id, CourseViewModel courses)
        {
            if (!ModelState.IsValid)
            {
                return View(courses);
            }

            bool isUpdated = await _courseService.UpdateCourseAsync(id, courses);

            if (!isUpdated)
            {
                return NotFound();
            }

            TempData["Success"] = "Course Updated Successfully";

            return RedirectToAction(nameof(Index));
        }

        #region API calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var coursesList =  await _courseService.GetAllCourseAsync();

            var viewModel = new CourseIndexViewModel
            {
                courses = coursesList
            };

            return Json(viewModel);
        }
        #endregion
    }

}
