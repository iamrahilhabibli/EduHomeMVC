﻿using System.Collections.Generic;
using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities
{
    public class EventDetails : BaseEntity
    {
        public string Description { get; set; }
        public override bool IsDeleted { get; set; }
        public ICollection<EventSpeaker> EventSpeakers { get; set; }
        public Event Event { get; set; }
    }
}
