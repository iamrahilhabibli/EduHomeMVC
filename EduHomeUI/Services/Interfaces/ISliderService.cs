using EduHome.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Services.Interfaces
{
    public interface ISliderService
    {
        Task<List<Slider>> GetAllSlidersAsync();
    }
}
