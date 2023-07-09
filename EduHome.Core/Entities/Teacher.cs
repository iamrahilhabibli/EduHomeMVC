using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities
{
    public class Teacher:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public string Position { get; set; }

    }
}
