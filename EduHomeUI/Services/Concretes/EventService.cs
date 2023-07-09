using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Services.Concretes
{
    public class EventService:IEventService
    {
        private readonly IEventService _eventService;
        private readonly AppDbContext _context;

        public EventService(AppDbContext context, IEventService eventService)
        {
            _context = context;
            _eventService = eventService;
        }

        public async Task<List<Event>> GetAllEventsAsync()
        {
            return await _context.Events.ToListAsync();
        }
    }
}
