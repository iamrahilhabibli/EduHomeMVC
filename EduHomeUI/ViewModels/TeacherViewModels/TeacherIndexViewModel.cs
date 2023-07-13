
using EduHome.Core.Entities;

namespace EduHomeUI.ViewModels.TeacherViewModels
{
    public class TeacherIndexViewModel
    {
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<TeacherDetails> Details { get; set; }
    }
}
