using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.SliderViewModels;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    [Area("EHMasterPanel")]
    [Authorize]
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
    }
}
