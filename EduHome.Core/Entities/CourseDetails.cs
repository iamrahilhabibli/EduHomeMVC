using EduHome.Core.Entities.Common;
using System.Collections.Generic;

namespace EduHome.Core.Entities
{
    public class CourseDetails : BaseEntity
    {
        public DateTime Start { get; set; }
        public string? Duration { get; set; }
        public string? ClassDuration { get; set; }
        public decimal CourseFee { get; set; }
        public Course? Course { get; set; }
        public ICollection<Language> LanguageOption { get; set; }
        public ICollection<Assesment> Assesment { get; set; }
        public ICollection<SkillLevel> Skill { get; set; }
        public int StudentCount { get; set; }
        public Guid LanguageOptionId { get; set; }
        public Guid AssesmentId { get; set; }
        public Guid SkillLevelId { get; set; }
        public ICollection<CourseDetailsSkillLevel> CourseDetailsSkillLevels { get; set; }
        public ICollection<CourseDetailsAssesment> CourseDetailsAssesments { get; set; }

        public CourseDetails()
        {
            LanguageOption = new List<Language>();
            Assesment = new List<Assesment>();
            Skill = new List<SkillLevel>();
            CourseDetailsSkillLevels = new List<CourseDetailsSkillLevel>();
            CourseDetailsAssesments = new List<CourseDetailsAssesment>();
        }
    }
}
