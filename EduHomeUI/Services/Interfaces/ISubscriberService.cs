using EduHome.Core.Entities;

namespace EduHomeUI.Services.Interfaces
{
    public interface ISubscriberService
    {
        Task<List<Subscribers>> GetAllSubscribersAsync();
        Task<bool> IsUserSubscribed(string email);
    }
}
