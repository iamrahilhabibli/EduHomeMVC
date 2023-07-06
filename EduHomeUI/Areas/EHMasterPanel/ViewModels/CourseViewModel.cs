using EduHome.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace EduHomeUI.Areas.EHMasterPanel.ViewModels
{
    public class CourseViewModel
    {
        [Required, MaxLength(10)]
        public string? Name { get; set; }
        [Required, MaxLength(120)]
        public string? Description { get; set; }
        [Required, MaxLength(255)]
        public string? ImagePath { get; set; }
        [Required, MaxLength(255)]
        public string ImageName { get; set; }
        [Required, MaxLength(255)]
        public string? AboutCourse { get; set; }
        [Required, MaxLength(255)]
        public string? HowToApply { get; set; }
        [Required, MaxLength(255)]
        public string? Certification { get; set; }
        public DateTime Start { get; set; }
        public string? Duration { get; set; }
        public string? ClassDuration { get; set; }
        public decimal CourseFee { get; set; }
        public int LanguageOptionId { get; set; }
        public int AssesmentId { get; set; }
        public int SkillLevelId { get; set; }

        public int CourseCategoryId { get; set; }
    }
}
