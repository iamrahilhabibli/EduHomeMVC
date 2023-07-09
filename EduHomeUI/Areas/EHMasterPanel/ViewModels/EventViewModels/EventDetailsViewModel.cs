using EduHome.Core.Entities;

namespace EduHomeUI.Areas.EHMasterPanel.ViewModels.EventViewModels
{
    public class EventDetailsViewModel
    {
        public string Title { get; set; }
        public string Venue { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Date { get; set; }
        public EventDetails EventDetails { get; set; }

        public ICollection<Speaker> Speakers { get; set; }
    }
}
