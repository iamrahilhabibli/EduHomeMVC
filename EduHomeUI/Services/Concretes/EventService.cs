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
                EventDetails = eventDetails,
                EventSpeakers = new List<EventSpeaker>()
            };

            _context.Events.Add(@event);
            await _context.SaveChangesAsync();

            if (eventVm.SpeakerId.HasValue)
            {
                var speaker = await _context.Speakers.FindAsync(eventVm.SpeakerId.Value);
                if (speaker != null)
                {
                    var eventSpeaker = new EventSpeaker
                    {
                        EventId = @event.Id,
                        SpeakerId = speaker.Id
                    };
                    @event.EventSpeakers.Add(eventSpeaker);
                }
            }

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteEventById(Guid skillId)
        {
            var newEvent = await _context.Events.FindAsync(skillId);

            if (newEvent is null)
            {
                return false;
            }

            newEvent.IsDeleted = true;
            _context.Events.Update(newEvent);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Event>> GetAllEventsAsync()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<bool> GetEventById(Guid eventId)
        {
            var newEvent = await _context.Events.FindAsync(eventId);
            if (newEvent is null) return false;
            return true;
        }

        public async Task<Event> GetEventByIdEvent(Guid eventId)
        {
            return await _context.Events.FindAsync(eventId);
        }
        public async Task<EventDetailsViewModel> GetEventDetailsViewModelAsync(Guid eventId)
        {
            var eventDetails = await _context.EventsDetails
                .Include(ed => ed.Event)
                .FirstOrDefaultAsync(ed => ed.Event.Id == eventId);

            if (eventDetails == null)
            {
                return null;
            }

            var eventSpeakers = await _context.EventSpeakers
                .Include(es => es.Speaker)
                .Where(es => es.EventId == eventId)
                .Select(es => es.Speaker)
                .ToListAsync();

            var eventDetailsViewModel = new EventDetailsViewModel
            {
                Title = eventDetails.Event.Title,
                ImagePath = eventDetails.Event.ImagePath,
                ImageName = eventDetails.Event.ImageName,
                StartTime = eventDetails.Event.StartTime,
                EndTime = eventDetails.Event.EndTime,
                Date = eventDetails.Event.Date,
                EventDetails = eventDetails,
                Speakers = eventSpeakers
            };

            return eventDetailsViewModel;
        }

        public Task<EventCreateViewModel> GetEventViewModelById(Guid eventId)
        {
            throw new NotImplementedException();
        }

        public async Task<EventUpdateViewModel> MapEventVM(Event @event)
        {
            var eventWithDetails = await _context.Events
                .Include(e => e.EventDetails)
                .FirstOrDefaultAsync(e => e.Id == @event.Id);

            if (eventWithDetails == null)
            {
                return null;
            }

            var eventViewModel = new EventUpdateViewModel
            {
                Id = eventWithDetails.Id,
                Title = eventWithDetails.Title,
                ImagePath = eventWithDetails.ImagePath,
                ImageName = eventWithDetails.ImageName,
                Venue = eventWithDetails.Venue,
                StartTime = eventWithDetails.StartTime,
                EndTime = eventWithDetails.EndTime,
                Date = eventWithDetails.Date,
                Description = eventWithDetails.EventDetails?.Description,
                Speakers = await _context.Speakers.Where(s => !s.IsDeleted).ToListAsync()
            };

            return eventViewModel;
        }


    }
}
