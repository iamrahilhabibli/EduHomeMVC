using EduHome.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace EduHomeUI.Areas.EHMasterPanel.ViewModels.TeacherViewModels
{
    public class TeacherUpdateViewModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name should only contain letters.")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Surname should only contain letters.")]
        public string Surname { get; set; }
        [Required]
        public string ImagePath { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "ImageName should only contain letters.")]
        public string ImageName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Position should only contain letters.")]
        public string Position { get; set; }

        [Required, MaxLength(10000)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "PhoneNumber should only contain digits.")]
        public string PhoneNumber { get; set; }

        [Required]
        public string SkypeAddress { get; set; }

        [Required, Range(0, 100)]
        public int LanguageSkills { get; set; }

        [Required, Range(0, 100)]
        public int TeamLeaderSkills { get; set; }

        [Required, Range(0, 100)]
        public int DevelopmentSkills { get; set; }

        [Required, Range(0, 100)]
        public int Design { get; set; }

        [Required, Range(0, 100)]
        public int Innovation { get; set; }

        [Required, Range(0, 100)]
        public int Communication { get; set; }
    }
}
