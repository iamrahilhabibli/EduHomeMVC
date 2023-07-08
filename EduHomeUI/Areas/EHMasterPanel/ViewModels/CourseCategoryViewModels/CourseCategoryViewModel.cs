using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.Models;
using System.ComponentModel.DataAnnotations;

namespace EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseCategoryViewModels
{
    public class CourseCategoryViewModel
    {
        [Required(ErrorMessage = "Category is required")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "Category cannot contain digits")]
        public string Category { get; set; }

        public DateTime DateModified { get; set; }
    }
}
