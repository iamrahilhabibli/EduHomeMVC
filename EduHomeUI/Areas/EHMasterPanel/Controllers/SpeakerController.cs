using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.LanguageViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.SpeakerViewModels;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    [Area("EHMasterPanel")]
    [Authorize]
    public class SpeakerController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ISpeakerService _speakerService;

        public SpeakerController(AppDbContext context,ISpeakerService speakerService)
        {
            _context = context;
            _speakerService = speakerService;
        }
        public async Task<IActionResult> Index()
        {
            var speakerList = await _context.Speakers.ToListAsync();

            var viewModel = new SpeakerIndexViewModel()
            {
                Speakers = speakerList
            };
            return View(viewModel);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpeakerCreateViewModel speakerVm)
        {
            if (!ModelState.IsValid) return NotFound();
            if (!await _speakerService.CreateSpeakerAsync(speakerVm)) return BadRequest();
            TempData["Success"] = "Speaker Created Successfully!";
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await _speakerService.GetSpeakerById(id)) return NotFound();

            var speaker = await _speakerService.GetSpeakerByIdSpeaker(id);

            var viewModel = new SpeakerDeleteViewModel()
            {
                Name = speaker.Name,
                Surname = speaker.Surname,
                ImagePath = speaker.ImagePath,
                CompanyName = speaker.CompanyName
            };
            return View(viewModel);
        }
        [HttpPost]
        [ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteSpeaker(Guid id)
        {
            bool isDeleted = await _speakerService.DeleteSpeakerById(id);

            if (!isDeleted) return NotFound();

            TempData["Success"] = "Speaker Deleted Successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
