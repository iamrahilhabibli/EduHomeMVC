using System.ComponentModel.DataAnnotations.Schema;
using EduHome.Core.Abstraction;

namespace EduHome.Core.Entities
{
    public class CourseDetails:BaseEntity
    {
        public Course Course { get; set; }
        [ForeignKey("Course")]
        public Guid CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public string Duration { get; set; }
        public string SkillLevel { get; set; }
        public string Language { get; set; }
        public int StudentCount { get; set; }
        public string Assesment { get; set; }
        public decimal Fee { get; set; }
    }
}
