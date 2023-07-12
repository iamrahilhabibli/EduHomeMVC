using EduHome.Core.Entities;

namespace EduHomeUI.Services.Interfaces
{
    public interface INoticeService
    {
        Task<List<Notice>> GetAllNotices();
    }
}
