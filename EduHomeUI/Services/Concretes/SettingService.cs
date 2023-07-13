using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.BlogViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.SettingViewModels;
using EduHomeUI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Services.Concretes
{
    public class SettingService : ISettingService
    {
        private readonly AppDbContext _context;
        public SettingService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Setting>> GetAllSettingsAsync()
        {
           return await _context.Settings.ToListAsync();
        }

        public async Task<bool> CreateSettingAsync(SettingCreateViewModel settingVm)
        {
            if (settingVm is null)
                return false;

            var setting = new Setting
            {
                Key = settingVm.Key,
                Value = settingVm.Value,

            };

            _context.Settings.Add(setting);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> GetSettingById(Guid settingId)
        {
            var setting = await _context.Settings.FindAsync(settingId);
            if (setting is null) return false;
            return true;
        }
        public async Task<Setting> GetSettingByIdSetting(Guid settingId)
        {
            return await _context.Settings.FindAsync(settingId);
        }

    }
}
