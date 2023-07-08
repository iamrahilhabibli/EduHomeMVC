using EduHome.Core.Entities.Common;
using System;
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
        public ICollection<CourseDetailsLanguage> CourseDetailsLanguages { get; set; }
        public int StudentCount { get; set; }
        public ICollection<CourseDetailsSkillLevel> CourseDetailsSkillLevels { get; set; }
        public ICollection<CourseDetailsAssesment> CourseDetailsAssesments { get; set; }

        public Guid LanguageOptionId { get; set; }
        public Guid AssesmentId { get; set; }
        public Guid SkillLevelId { get; set; }

        public CourseDetails()
        {
            CourseDetailsLanguages = new List<CourseDetailsLanguage>();
            CourseDetailsSkillLevels = new List<CourseDetailsSkillLevel>();
            CourseDetailsAssesments = new List<CourseDetailsAssesment>();
        }
    }
}
