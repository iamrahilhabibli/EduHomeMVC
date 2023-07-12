using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
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
        public async Task<List<Notice>> GetAllNotices()
        {
            return await _context.Notices.ToListAsync();
        }
    }
}
