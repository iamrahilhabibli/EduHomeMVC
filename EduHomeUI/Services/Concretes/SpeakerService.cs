using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Services.Concretes
{
    public class SpeakerService : ISpeakerService
    {
        private readonly AppDbContext _context;
        public SpeakerService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Speaker>> GetAllSpeakers()
        {
            return await _context.Speakers.ToListAsync();
        }
    }
}
