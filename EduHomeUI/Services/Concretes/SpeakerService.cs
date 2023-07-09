using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.LanguageViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.SpeakerViewModels;
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

        public async Task<bool> CreateSpeakerAsync(SpeakerCreateViewModel speakerVm)
        {
            if (speakerVm is null) return false;
            Speaker newSpeaker = new()
            {
                Name = speakerVm.Name,
                Surname = speakerVm.Surname,
                ImageName = speakerVm.ImageName,
                ImagePath = speakerVm.ImagePath,
                Position = speakerVm.Position,
                CompanyName = speakerVm.CompanyName,
                IsDeleted = false
            };
            _context.Speakers.Add(newSpeaker);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Speaker>> GetAllSpeakers()
        {
            return await _context.Speakers.ToListAsync();
        }
    }
}
