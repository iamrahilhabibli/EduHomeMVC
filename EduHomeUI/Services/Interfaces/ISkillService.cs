using EduHomeUI.Areas.EHMasterPanel.ViewModels.SkillViewModels;

namespace EduHomeUI.Services.Interfaces
{
    public interface ISkillService
    {
        Task<bool> CreateSkillAsync(SkillViewModel skillVM);
    }
}
