using EduHome.Core.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Core.Entities
{
    public class TeacherDetails : BaseEntity
    {
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string SkypeAddress { get; set; }
        public int LanguageSkills { get; set; }
        public int TeamLeaderSkills { get; set; }
        public int DevelopmentSkills { get; set; }
        public override bool IsDeleted { get; set; }
        public int Design { get; set; }
        public int Innovation { get; set; }
        public int Communication { get; set; }

        [ForeignKey("Teacher")]
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
