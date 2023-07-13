using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities
{
    public class CourseBuyers:BaseEntity
    {
        public int CourseId { get; set; }
        public int UserId { get; set; }
    }
}
