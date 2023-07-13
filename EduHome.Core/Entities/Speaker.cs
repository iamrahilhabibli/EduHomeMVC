using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities
{
    public  class Speaker:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string CompanyName { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public override bool IsDeleted { get; set; }

        public ICollection<EventSpeaker> EventSpeakers { get; set; }
    }
}
