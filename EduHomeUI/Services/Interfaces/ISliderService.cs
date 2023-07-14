using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.SliderViewModels;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Services.Interfaces
{
    public interface ISliderService
    {
        Task<List<Slider>> GetAllSlidersAsync();
        Task<bool> CreateSliderAsync(SliderCreateViewModel sliderVm);
    }
}
