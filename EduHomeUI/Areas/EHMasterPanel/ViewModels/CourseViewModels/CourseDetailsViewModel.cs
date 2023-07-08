using EduHome.Core.Entities;
using System;
using System.Collections.Generic;

namespace EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels
{
    public class CourseDetailsViewModel
    {
        public CourseDetailsViewModel Course { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public string? ImageName { get; set; }
        public DateTime Start { get; set; }
        public string? Duration { get; set; }
        public string? ClassDuration { get; set; }
        public decimal CourseFee { get; set; }
        public int StudentCount { get; set; }
        public List<SkillLevel> CourseDetailsSkills { get; set; }
        public List<Language> CourseDetailsLanguages { get; set; }
        public List<Assesment> CourseDetailsAssesments { get; set; }

        public CourseDetailsViewModel()
        {
            CourseDetailsSkills = new List<SkillLevel>();
            CourseDetailsLanguages = new List<Language>();
            CourseDetailsAssesments = new List<Assesment>();
        }
    }
}
