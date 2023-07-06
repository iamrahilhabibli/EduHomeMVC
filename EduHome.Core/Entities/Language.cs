using EduHome.Core.Interfaces;

namespace EduHome.Core.Entities
{
    public class Language : IEntity
    {
        public int Id { get; set; }
        public string? LanguageOption { get; set; }
        CourseDetails? CourseDetail { get; set; }

    }
}
