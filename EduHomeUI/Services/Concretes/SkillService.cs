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
                Skill = skillVM.Skill
            };
            await _context.SkillLevels.AddAsync(newSkill);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<SkillLevel>> GetAllSkills()
        {
           return await _context.SkillLevels.ToListAsync();
        }
        public async Task<bool> DeleteSkillLevelById(Guid skillId)
        {
            var skills = await _context.SkillLevels.FindAsync(skillId);

            if (skills is null)
            {
                return false;
            }

            skills.IsDeleted = true;
            _context.SkillLevels.Update(skills);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> GetSkillLevelById(Guid skillId)
        {
            var skill = await _context.SkillLevels.FindAsync(skillId);
            if (skill is null) return false;
            return true;
        }
        public async Task<SkillLevel> GetSkillLevelByIdSkillLevel(Guid skillId)
        {
            return await _context.SkillLevels.FindAsync(skillId);
        }
    }
}
