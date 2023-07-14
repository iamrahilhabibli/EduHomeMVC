using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.BlogViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.SliderViewModels;
using EduHomeUI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Services.Concretes
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;
        public SliderService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Slider>> GetAllSlidersAsync()
        {
            return await _context.Sliders.ToListAsync();
        }
        public async Task<bool> CreateSliderAsync(SliderCreateViewModel sliderVm)
        {
            if (sliderVm is null)
                return false;

            var slider = new Slider
            {
                ImageName = sliderVm.ImageName,
                ImagePath = sliderVm.ImagePath,
                Title = sliderVm.Title,
                Description = sliderVm.Description
            };

            _context.Sliders.Add(slider);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
