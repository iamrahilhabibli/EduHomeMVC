using System.ComponentModel.DataAnnotations;

namespace EduHomeUI.Areas.EHMasterPanel.ViewModels.SpeakerViewModels
{
    public class SpeakerCreateViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name should only contain letters")]
        [MaxLength(30, ErrorMessage = "Name cannot exceed 30 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Surname should only contain letters")]
        [MaxLength(50, ErrorMessage = "Surname cannot exceed 50 characters")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Position is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Position should only contain letters")]
        [MaxLength(30, ErrorMessage = "Position cannot exceed 30 characters")]
        public string Position { get; set; }

        [Required(ErrorMessage = "CompanyName is required")]
        [MaxLength(30, ErrorMessage = "CompanyName cannot exceed 30 characters")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "ImagePath is required")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "ImageName is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "ImageName should only contain letters")]
        [MaxLength(20, ErrorMessage = "ImageName cannot exceed 20 characters")]
        public string ImageName { get; set; }

    }
}
