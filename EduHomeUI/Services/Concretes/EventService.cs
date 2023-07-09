using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.EventViewModels;
using EduHomeUI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Services.Concretes
{
    public class EventService:IEventService
    {
        private readonly AppDbContext _context;

        public EventService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateEventAsync(EventCreateViewModel eventVm)
        {
            if (eventVm is null)
                return false;

            var eventDetails = new EventDetails
            {
                Description = eventVm.Description
            };

            var @event = new Event
            {
                Title = eventVm.Title,
                ImagePath = eventVm.ImagePath,
                ImageName = eventVm.ImageName,
                Venue = eventVm.Venue,
                StartTime = eventVm.StartTime,
                EndTime = eventVm.EndTime,
                Date = eventVm.Date,
                EventDetails = eventDetails
            };

            if (eventVm.SpeakerId != null)
            {
                var speaker = await _context.Speakers.FindAsync(eventVm.SpeakerId);
                if (speaker != null)
                {
                    var eventSpeaker = new EventSpeaker
                    {
                        SpeakerId = speaker.Id,
                        EventId = @event.Id
                    };

                    @event.EventSpeakers.Add(eventSpeaker);
                }
            }

            _context.EventsDetails.Add(eventDetails);
            _context.Events.Add(@event);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<List<Event>> GetAllEventsAsync()
        {
            return await _context.Events.ToListAsync();
        }
    }
}
