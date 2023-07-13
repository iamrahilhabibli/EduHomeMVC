using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.SettingViewModels;

namespace EduHomeUI.Services.Interfaces
{
    public interface ISettingService
    {
        Task<List<Setting>> GetAllSettingsAsync();
        Task<bool> CreateSettingAsync(SettingCreateViewModel settingVm);
        Task<bool> GetSettingById(Guid settingId);
        Task<Setting> GetSettingByIdSetting(Guid settingId);
        Task<bool> DeleteSettingById(Guid settingId);
    }
}
