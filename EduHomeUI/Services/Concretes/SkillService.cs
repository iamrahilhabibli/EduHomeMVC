using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.SkillViewModels;
using EduHomeUI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Services.Concretes
{
    public class SkillService : ISkillService
    {
        private readonly AppDbContext _context;

        public SkillService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateSkillAsync(SkillViewModel skillVM)
        {
            if (skillVM == null) { return false; }
            SkillLevel newSkill = new()
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Skill = skillVM.Skill
            };
            await _context.SkillLevels.AddAsync(newSkill);
            _context.SaveChanges();
            return true;
        }

        public async Task<List<SkillLevel>> GetAllSkills()
        {
           return await _context.SkillLevels.ToListAsync();
        }
    }
}
