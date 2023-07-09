using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.LanguageViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.SpeakerViewModels;

namespace EduHomeUI.Services.Interfaces
{
    public interface ISpeakerService
    {
        Task<List<Speaker>> GetAllSpeakers();
        Task<bool> CreateSpeakerAsync(SpeakerCreateViewModel speakerVm);
    }
}
