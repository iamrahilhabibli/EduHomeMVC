using EduHome.Core.Entities;

namespace EduHomeUI.ViewModels.CourseViewModels
{
    public class CourseIndexViewModel
    {
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<CourseDetails> CourseDetails { get; set;}
    }
}
