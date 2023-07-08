using System.ComponentModel.DataAnnotations;

namespace EduHomeUI.Areas.EHMasterPanel.ViewModels.LanguageViewModels
{
    public class LanguageViewModel
    {
        [Required(ErrorMessage = "Language option is required")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Language option can only contain letters")]
        [MaxLength(20, ErrorMessage = "Language option cannot exceed 20 characters")]
        public string? LanguageOption { get; set; }
    }
}
