using System.ComponentModel.DataAnnotations;

namespace EduHomeUI.Areas.EHMasterPanel.ViewModels.AssesmentViewModels
{
    public class AssesmentViewModel
    {
        [Required(ErrorMessage = "Assesment type is required")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Assesment type can only contain letters")]
        [MaxLength(50, ErrorMessage = "Assesment type cannot exceed 50 characters")]
        public string? AssesmentType { get; set; }
    }
}