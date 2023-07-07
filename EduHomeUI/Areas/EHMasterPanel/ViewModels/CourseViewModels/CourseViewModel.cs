using EduHome.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels
{
    public class CourseViewModel
    {
        [Required, MaxLength(10)]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required, MaxLength(255)]
        public string? ImagePath { get; set; }
        [Required, MaxLength(255)]
        public string ImageName { get; set; }
        public DateTime Start { get; set; }
        public string? Duration { get; set; }
        public string? ClassDuration { get; set; }
        public decimal CourseFee { get; set; }
        public Guid LanguageOptionId { get; set; }
        public Guid AssesmentId { get; set; }
        public Guid SkillLevelId { get; set; }

        public Guid CourseCategoryId { get; set; }
    }
}
