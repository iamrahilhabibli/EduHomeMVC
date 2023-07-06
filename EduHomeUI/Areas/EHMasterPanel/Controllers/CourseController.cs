using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    [Area("EHMasterPanel")]
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CourseController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.courses.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CourseViewModel courses)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Course newCourse = _mapper.Map<Course>(courses);

            CourseDetails details = new CourseDetails
            {
                StartDate = courses.StartDate,
                Duration = courses.Duration,
                SkillLevel = courses.SkillLevel,
                Language = courses.Language,
                StudentCount = courses.StudentCount,
                Assesment = courses.Assesment,
                Fee = courses.Fee
            };
            CourseCategory category = new CourseCategory
            {
                Category = courses.Category
            };


            newCourse.Details = details;
            newCourse.CourseCatagory = category;

            await _context.courses.AddAsync(newCourse);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Course Created Successfully";
            return RedirectToAction(nameof(Index));
        }




        //public async Task<IActionResult> Delete(int Id)
        //{
        //    Courses course = await _context.courses.FindAsync(Id);
        //    if (course == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(course);
        //}
        //[HttpPost]
        //[ActionName("Delete")]
        //[AutoValidateAntiforgeryToken]
        //public async Task<IActionResult> DeletePost(int Id)
        //{
        //    Courses course = await _context.courses.FindAsync(Id);
        //    if (course == null)
        //    {
        //        return NotFound();
        //    }

        //    CourseDetails details = await _context.courseDetails.FindAsync(course.Id);
        //    if (details != null)
        //    {
        //        _context.courseDetails.Remove(details);
        //    }

        //    _context.courses.Remove(course);
        //    await _context.SaveChangesAsync();
        //    TempData["Success"] = "Course Deleted Successfully";

        //    return RedirectToAction(nameof(Index));
        //}


        //public async Task<IActionResult> Update(int Id)
        //{
        //    Courses course = await _context.courses.FindAsync(Id);
        //    if (course == null)
        //    {
        //        return NotFound();
        //    }

        //    CoursesViewModel courseViewModel = _mapper.Map<CoursesViewModel>(course);
        //    return View(courseViewModel);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Update(int id, CoursesViewModel courses)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(courses);
        //    }

        //    Courses course = await _context.courses.Include(c => c.Details).FirstOrDefaultAsync(c => c.Id == id);
        //    if (course == null)
        //    {
        //        return NotFound();
        //    }

        //    course.Name = courses.Name;
        //    course.Description = courses.Description;
        //    course.ImagePath = courses.ImagePath;

        //    if (course.Details != null)
        //    {
        //        course.Details.StartDate = courses.StartDate;
        //        course.Details.Duration = courses.Duration;
        //        course.Details.SkillLevel = courses.SkillLevel;
        //        course.Details.Language = courses.Language;
        //        course.Details.StudentCount = courses.StudentCount;
        //        course.Details.Assesment = courses.Assesment;
        //        course.Details.Fee = courses.Fee;

        //        _context.Entry(course.Details).State = EntityState.Modified;
        //    }
        //    else
        //    {
        //        CourseDetails newDetails = new CourseDetails
        //        {
        //            StartDate = courses.StartDate,
        //            Duration = courses.Duration,
        //            SkillLevel = courses.SkillLevel,
        //            Language = courses.Language,
        //            StudentCount = courses.StudentCount,
        //            Assesment = courses.Assesment,
        //            Fee = courses.Fee
        //        };
        //        course.Details = newDetails;
        //        _context.courseDetails.Add(newDetails);
        //    }

        //    _context.Entry(course).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();

        //    TempData["Success"] = "Course Updated Successfully";

        //    return RedirectToAction(nameof(Index));
        //}
    }
}
