using EduHome.Core.Entities;
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
            var skillsList = await _skillService.GetAllSkills();

            var viewModel = new SkillIndexViewModel()
            {
                SkillLevels = skillsList
            };
            return View(viewModel);
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
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await _skillService.GetSkillLevelById(id)) return NotFound();

            var skill = await _skillService.GetSkillLevelByIdSkillLevel(id);

            var viewModel = new SkillViewModel()
            {
                Skill = skill.Skill
            };
            return View(viewModel);
        }
        [HttpPost]
        [ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteSKillLevel(Guid id)
        {
            //bool isDeleted = await _skillService.DeleteSkillLevelById(id);

            //if (!isDeleted) return NotFound();

            //TempData["Success"] = "SkillLevel Deleted Successfully";
            //return RedirectToAction(nameof(Index));
            SkillLevel skillLevel = await _context.SkillLevels.FindAsync(id);
            if (skillLevel is null)
            {
                return NotFound();
            }
            _context.SkillLevels.Remove(skillLevel);
            _context.SaveChanges();
            TempData["Success"] = "SkillLevel Deleted Successfully";
            return RedirectToAction(nameof(Index));
        }

    }
}
