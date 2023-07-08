﻿using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.SkillViewModels;

namespace EduHomeUI.Services.Interfaces
{
    public interface ISkillService
    {
        Task<bool> CreateSkillAsync(SkillViewModel skillVM);
        Task<List<SkillLevel>> GetAllSkills();
    }
}
