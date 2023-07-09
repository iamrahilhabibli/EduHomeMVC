namespace EduHome.Core.Entities
{
    public class EventSpeaker
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; }

        public Guid SpeakerId { get; set; }
        public Speaker Speaker { get; set; }
    }
}
