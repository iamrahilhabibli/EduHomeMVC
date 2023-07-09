using EduHome.Core.Entities;

namespace EduHomeUI.Services.Interfaces
{
    public interface ISpeakerService
    {
        Task<List<Speaker>> GetAllSpeakers();
    }
}
