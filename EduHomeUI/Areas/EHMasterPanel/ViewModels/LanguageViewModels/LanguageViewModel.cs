using System.ComponentModel.DataAnnotations;

namespace EduHomeUI.Areas.EHMasterPanel.ViewModels.LanguageViewModels
{
    public class LanguageViewModel
    {
        [Required(ErrorMessage = "Language option is required")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Language option can only contain letters")]
        [MaxLength(50, ErrorMessage = "Language option cannot exceed 50 characters")]
        public string? LanguageOption { get; set; }
    }
}
