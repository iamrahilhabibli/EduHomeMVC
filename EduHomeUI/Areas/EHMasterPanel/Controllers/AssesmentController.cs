using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.AssesmentViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.LanguageViewModels;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
	[Area("EHMasterPanel")]
	public class AssesmentController : Controller
	{
		private readonly AppDbContext _context;
		private readonly IAssesmentService _assesmentService;

        public AssesmentController(AppDbContext context,IAssesmentService assesmentService)
        {
			_context = context;
			_assesmentService = assesmentService;
        }
        public IActionResult Index()
		{
			return View();
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
			TempData["Success"] = "Language Created Successfully!";
			return RedirectToAction("Index", "Dashboard");
		}
	}
}
