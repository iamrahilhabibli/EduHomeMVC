using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.AssesmentViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.LanguageViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.SkillViewModels;
using EduHomeUI.Services.Concretes;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
	[Area("EHMasterPanel")]
    [Authorize]
	public class AssesmentController : Controller
	{
		private readonly AppDbContext _context;
		private readonly IAssesmentService _assesmentService;

        public AssesmentController(AppDbContext context,IAssesmentService assesmentService)
        {
			_context = context;
			_assesmentService = assesmentService;
        }
        public async Task<IActionResult> Index()
		{
            var assesmentsList = await _assesmentService.GetAllAssesment();

            var viewModel = new AssesmentIndexViewModel
            {
                Assesments = assesmentsList
            };

            return View(viewModel);
        }
		public async Task<IActionResult> Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(AssesmentViewModel assesmentVm)
		{
			if (!ModelState.IsValid) return NotFound();
			if (!await _assesmentService.CreateAssesmentAsync(assesmentVm)) return BadRequest();
			TempData["Success"] = "Assesment Created Successfully!";
			return RedirectToAction(nameof(Index));
		}
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await _assesmentService.GetAssesmentById(id)) return NotFound();

            var assesment = await _assesmentService.GetAssesmentByIdAssesment(id);

            var viewModel = new AssesmentViewModel()
            {
                AssesmentType = assesment.AssesmentType
            };
            return View(viewModel);
        }
        [HttpPost]
        [ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteAssesmentType(Guid id)
        {
            //bool isDeleted = await _assesmentService.DeleteAssesmentById(id);

            //if (!isDeleted) return NotFound();

            //TempData["Success"] = "Assesment Deleted Successfully";
            //return RedirectToAction(nameof(Index));
            Assesment assesment = await _context.Assesments.FindAsync(id);
            if (assesment is null)
            {
                return NotFound();
            }
            _context.Assesments.Remove(assesment);
            _context.SaveChanges();
            TempData["Success"] = "Assesment Removed Successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
