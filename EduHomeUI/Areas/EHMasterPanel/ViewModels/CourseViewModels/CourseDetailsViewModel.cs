using EduHome.Core.Entities;

namespace EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels
{
	public class CourseDetailsViewModel
	{
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public string? ImageName { get; set; }
        public DateTime Start { get; set; }
        public string? Duration { get; set; }
        public string? ClassDuration { get; set; }
        public decimal CourseFee { get; set; }
        public int StudentCount { get; set; }
    }
}
