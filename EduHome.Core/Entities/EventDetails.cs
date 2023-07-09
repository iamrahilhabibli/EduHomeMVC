using System.Collections.Generic;
using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities
{
    public class EventDetails : BaseEntity
    {
        public string Description { get; set; }

        public ICollection<EventSpeaker> EventSpeakers { get; set; }
    }
}
