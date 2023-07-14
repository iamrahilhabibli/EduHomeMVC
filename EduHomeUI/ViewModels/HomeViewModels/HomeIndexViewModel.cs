using EduHome.Core.Entities;

namespace EduHomeUI.ViewModels.HomeViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Notice> Notices { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Slider> Sliders { get; set; }
    }
}
