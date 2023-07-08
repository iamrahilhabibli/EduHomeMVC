﻿using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.AssesmentViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.LanguageViewModels;
using EduHomeUI.Services.Concretes;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
	}
}
