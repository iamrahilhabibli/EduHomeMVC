using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.EventViewModels;

namespace EduHomeUI.Services.Interfaces
{
    public interface IEventService
    {
        Task<List<Event>> GetAllEventsAsync();
        Task<bool> CreateEventAsync(EventCreateViewModel eventVm);
        Task<bool> GetEventById(Guid eventId);
        Task<Event> GetEventByIdEvent(Guid eventId);

        Task<bool> DeleteEventById(Guid skillId);
        Task<EventDetailsViewModel> GetEventDetailsViewModelAsync(Guid eventId);
        Task<EventCreateViewModel> GetEventViewModelById(Guid eventId);
        Task<EventUpdateViewModel> MapEventVM(Event @event);
        Task<bool> UpdateEventAsync(Guid eventId, EventUpdateViewModel eventVm);
        Task<bool> GetEventDetailById(Guid eventId);
        Task<bool> UpdateEventDetailIsDeleted(Guid eventId, bool isDeleted);
        Task<bool> UpdateEventIsDeleted(Guid eventId, bool isDeleted);
    }
}
