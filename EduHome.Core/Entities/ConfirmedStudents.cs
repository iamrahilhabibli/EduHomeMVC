using EduHome.Core.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Core.Entities
{
    public class ConfirmedStudents:BaseEntity
    {
        public bool IsDeleted { get; set; }
        [ForeignKey("AppUser")]
        public Guid UserId { get; set; }

        [ForeignKey("Course")]
        public Guid CourseId { get; set; }
        public AppUser User { get; set; }
        public Course Course { get; set; }
    }  
}
