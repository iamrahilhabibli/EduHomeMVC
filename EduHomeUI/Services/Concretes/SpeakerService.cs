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

        public async Task<bool> DeleteSpeakerById(Guid speakerId)
        {
            var speaker = await _context.Speakers.FindAsync(speakerId);

            if (speaker is null)
            {
                return false;
            }

            speaker.IsDeleted = true;
            _context.Speakers.Update(speaker);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Speaker>> GetAllSpeakers()
        {
            return await _context.Speakers.ToListAsync();
        }
        public async Task<bool> GetSpeakerById(Guid speakerId)
        {
            var speaker = await _context.Speakers.FindAsync(speakerId);
            if (speaker is null) return false;
            return true;
        }
        public async Task<Speaker> GetSpeakerByIdSpeaker(Guid speakerId)
        {
            return await _context.Speakers.FindAsync(speakerId);
        }
    }
}
