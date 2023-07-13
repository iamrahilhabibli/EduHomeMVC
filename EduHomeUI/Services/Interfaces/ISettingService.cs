using EduHome.Core.Entities;

namespace EduHomeUI.Services.Interfaces
{
    public interface ISettingService
    {
        Task<List<Setting>> GetAllSettingsAsync();
    }
}
