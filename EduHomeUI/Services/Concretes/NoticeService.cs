using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.LanguageViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.NoticeViewModels.cs;
using EduHomeUI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Services.Concretes
{
    public class NoticeService : INoticeService
    {
        private readonly AppDbContext _context;

        public NoticeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateNoticeAsync(NoticeCreateViewModel noticeVm)
        {
            if (noticeVm is null) return false;
            Notice newNotice = new()
            {
                Description = noticeVm.Description,
                IsDeleted = false
            };
            _context.Notices.Add(newNotice);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Notice>> GetAllNotices()
        {
            return await _context.Notices.ToListAsync();
        }
    }
}
