using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities
{
	public class Language : BaseEntity
    {
        public string? LanguageOption { get; set; }
        CourseDetails? CourseDetail { get; set; }

    }
}
