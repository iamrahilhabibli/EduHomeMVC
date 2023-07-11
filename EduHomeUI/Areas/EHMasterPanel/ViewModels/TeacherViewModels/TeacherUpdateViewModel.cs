using EduHome.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace EduHomeUI.Areas.EHMasterPanel.ViewModels.TeacherViewModels
{
    public class TeacherUpdateViewModel
    {

        public string Name { get; set; }

        public string Surname { get; set; }

        public string ImagePath { get; set; }

        public string ImageName { get; set; }

        public string Position { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string SkypeAddress { get; set; }

        public int LanguageSkills { get; set; }


        public int TeamLeaderSkills { get; set; }

        public int DevelopmentSkills { get; set; }

        public int Design { get; set; }


        public int Innovation { get; set; }


        public int Communication { get; set; }
    }
}
