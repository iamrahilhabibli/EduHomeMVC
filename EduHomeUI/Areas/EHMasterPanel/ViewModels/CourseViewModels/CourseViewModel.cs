using System;
using System.ComponentModel.DataAnnotations;

namespace EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels
{
    public class CourseViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "ImagePath is required")]
        [MaxLength(255, ErrorMessage = "ImagePath cannot exceed 255 characters")]
        public string? ImagePath { get; set; }

        [Required(ErrorMessage = "ImageName is required")]
        [MaxLength(255, ErrorMessage = "ImageName cannot exceed 255 characters")]
        public string ImageName { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        public DateTime Start { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        public string? Duration { get; set; }

        [Required(ErrorMessage = "Class duration is required")]
        public string? ClassDuration { get; set; }

        [Required(ErrorMessage = "Course fee is required")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Course fee must be a numeric value")]
        public decimal CourseFee { get; set; }


        public Guid LanguageOptionId { get; set; }

        public Guid AssesmentId { get; set; }

        public Guid SkillLevelId { get; set; }
        public Guid CourseCategoryId { get; set; }
    }
}
