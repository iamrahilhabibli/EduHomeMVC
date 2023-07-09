using EduHome.Core.Entities;

namespace EduHomeUI.Services.Interfaces
{
    public interface IEventService
    {
        Task<List<Event>> GetAllEventsAsync();
    }
}
