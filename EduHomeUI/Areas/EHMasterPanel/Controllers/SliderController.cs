using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.BlogViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.SliderViewModels;
using EduHomeUI.Services.Concretes;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    [Area("EHMasterPanel")]
    [Authorize(Roles = "Master,Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ISliderService _sliderService;
        public SliderController(AppDbContext context,ISliderService sliderService)
        {
            _context = context;
            _sliderService = sliderService;
        }
        public async Task<IActionResult> Index()
        {
            var sliderList = await _sliderService.GetAllSlidersAsync();
            SliderIndexViewModel viewModel = new()
            {
                Sliders = sliderList
            };
            return View(viewModel);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(SliderCreateViewModel sliderVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _sliderService.CreateSliderAsync(sliderVm)) return BadRequest();
            TempData["Success"] = "Slider Created Successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
