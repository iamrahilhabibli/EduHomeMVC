using System.ComponentModel.DataAnnotations;

namespace EduHomeUI.Areas.EHMasterPanel.ViewModels.SkillViewModels
{
    public class SkillViewModel
    {
        [Required(ErrorMessage = "Skill is required")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Skill can only contain letters")]
        [MaxLength(20, ErrorMessage = "Skill cannot exceed 20 characters")]
        public string? Skill { get; set; }
    }
}
