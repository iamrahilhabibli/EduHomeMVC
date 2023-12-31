﻿using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseCategoryViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.TeacherViewModels;
using EduHomeUI.Services.Concretes;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    [Area("EHMasterPanel")]
    [Authorize(Roles = "Master,Admin")]
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

        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await _service.GetTeacherById(id))
            {
                return NotFound();
            }

            var teacher = await _service.GetTeacherByIdTeacher(id);

            var viewModel = _service.MapDeleteVM(teacher);

            return View(await viewModel);
        }
        [HttpPost]
        [ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteTeacher(Guid id)
        {
            bool isDeleted = await _service.DeleteTeacherById(id);

            if (!isDeleted) return NotFound();

            TempData["Success"] = "Teacher Deleted Successfully";
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(Guid Id)
        {
            Teacher teacher = _context.Teachers.Find(Id);
            if (teacher == null)
            {
                return NotFound();
            }

            var viewModel = await _service.MapTeacherVM(teacher);

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Guid id, TeacherUpdateViewModel teacher)
        {
            if (!ModelState.IsValid)
            {
                return View(teacher);
            }

            bool isUpdated = await _service.UpdateTeacherAsync(id, teacher);

            if (!isUpdated)
            {
                return NotFound();
            }

            TempData["Success"] = "Teacher Updated Successfully";

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var teacherDetailsView = await _service.GetTeacherDetailsViewModelAsync(id);
            if (teacherDetailsView is null) return NotFound();

            return View(teacherDetailsView);
        }
    }
}
