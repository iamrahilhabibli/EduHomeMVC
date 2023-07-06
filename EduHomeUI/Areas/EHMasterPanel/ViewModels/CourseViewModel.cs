using EduHome.Core.Entities;

namespace EduHomeUI.Areas.EHMasterPanel.ViewModels
{
    public class CourseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public DateTime StartDate { get; set; }
        public string Duration { get; set; }
        public string SkillLevel { get; set; }
        public string Language { get; set; }
        public int StudentCount { get; set; }
        public string Assesment { get; set; }
        public decimal Fee { get; set; }
        public int CategoryId { get; set; }
    }
}
