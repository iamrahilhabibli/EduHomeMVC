using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities
{
    public class Event:BaseEntity
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public string Venue { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Date { get; set; }
        public Guid EventDetailsId { get; set; }
        public EventDetails EventDetails { get; set; }

        public ICollection<EventSpeaker> EventSpeakers { get; set; }
    }
}
