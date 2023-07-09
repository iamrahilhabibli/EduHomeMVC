using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.EventViewModels;

namespace EduHomeUI.Services.Interfaces
{
    public interface IEventService
    {
        Task<List<Event>> GetAllEventsAsync();
        Task<bool> CreateEventAsync(EventCreateViewModel eventVm);
    }
}
