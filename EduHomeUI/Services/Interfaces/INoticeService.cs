using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.LanguageViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.NoticeViewModels.cs;

namespace EduHomeUI.Services.Interfaces
{
    public interface INoticeService
    {
        Task<List<Notice>> GetAllNotices();
        Task<bool> CreateNoticeAsync(NoticeCreateViewModel noticeVm);
        Task<bool> GetNoticeById(Guid noticeId);
        Task<Notice> GetNoticeByIdNotice(Guid noticeId);

        Task<bool> DeleteNoticeById(Guid noticeId);
    }
}
