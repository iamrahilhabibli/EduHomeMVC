using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.LanguageViewModels;

namespace EduHomeUI.Services.Interfaces
{
    public interface INoticeService
    {
        Task<List<Notice>> GetAllNotices();
        Task<bool> CreateNoticeAsync(LanguageViewModel languageVm);
    }
}
