﻿using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.TeacherViewModels;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    [Area("EHMasterPanel")]
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ITeacherService _service;

        public TeacherController(AppDbContext context, ITeacherService service) 
        {
            _context = context;
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var teachers = await _service.GetAllTeachersAsync();

            var viewModel = new TeacherIndexViewModel()
            {
                Teachers = teachers
            };
            return View(viewModel);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(TeacherCreateViewModel teacherVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _service.CreateTeacherAsync(teacherVm)) return BadRequest();
            TempData["Success"] = "Teacher Created Successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
