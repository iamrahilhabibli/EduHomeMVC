using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.Models;
using System.ComponentModel.DataAnnotations;

namespace EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseCategoryViewModels
{
    public class CourseCategoryViewModel
    {
        public string Category { get; set; }


        public DateTime DateModified { get; set; }
    }
}
