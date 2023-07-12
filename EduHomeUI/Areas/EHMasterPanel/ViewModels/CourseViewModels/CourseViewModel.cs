using System;

namespace EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels
{
    public class CourseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public DateTime Start { get; set; }
        public string Duration { get; set; }
        public string ClassDuration { get; set; }
        public decimal CourseFee { get; set; }
        public int StudentCount { get; set; }
        public Guid LanguageOptionId { get; set; }
        public Guid AssesmentId { get; set; }
        public Guid SkillLevelId { get; set; }
        public Guid CourseCategoryId { get; set; }
    }
}
