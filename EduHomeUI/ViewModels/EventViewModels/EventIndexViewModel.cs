using EduHome.Core.Entities;

namespace EduHomeUI.ViewModels.EventViewModels
{
    public class EventIndexViewModel
    {
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<EventDetails> Details { get; set; }
        public IEnumerable<Speaker> Speakers { get; set; }
        public IEnumerable<EventSpeaker> EventSpeakers { get; set;}
    }
}
