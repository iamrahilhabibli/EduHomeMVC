using EduHome.Core.Entities;

namespace EduHomeUI.Areas.EHMasterPanel.ViewModels.EventViewModels
{
    public class EventCreateViewModel
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public string Venue { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Guid SpeakerId { get; set; }

        public List<Speaker> Speakers { get; set; }
    }
}
