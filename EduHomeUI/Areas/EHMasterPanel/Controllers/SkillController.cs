using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.AssesmentViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.SkillViewModels;
using EduHomeUI.Services.Concretes;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    [Area("EHMasterPanel")]
    public class SkillController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ISkillService _skillService;

        public SkillController(AppDbContext context,ISkillService skillService)
        {
            _context = context;
            _skillService = skillService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.SkillLevels.ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SkillViewModel skillVm)
        {
            if (!ModelState.IsValid) return NotFound();
            if (!await _skillService.CreateSkillAsync(skillVm)) return BadRequest();
            TempData["Success"] = "Skill Created Successfully!";
            return RedirectToAction("Index", "Dashboard");
        }

    }
}
