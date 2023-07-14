using EduHome.Core.Entities;

namespace EduHomeUI.ViewModels.AboutViewModels
{
    public class AboutIndexViewModel
    {
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Notice> Notices { get; set; }
    }
}
