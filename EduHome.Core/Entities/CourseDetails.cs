using EduHome.Core.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Core.Entities
{
    public class CourseDetails : BaseEntity
    {
      
        public DateTime Start { get; set; }
        public string? Duration { get; set; }
        public string? ClassDuration { get; set; }
        public decimal CourseFee { get; set; }
        public Course? Course { get; set; } 

        public Language? LanguageOption { get; set; } 
        public Assesment? Assesment { get; set; }
        public SkillLevel? Skill { get; set; } 

        public Guid LanguageOptionId { get; set; }
        public Guid AssesmentId { get; set; }
        public Guid SkillId { get; set; }
        public int StudentCount { get; set; }
    }
}