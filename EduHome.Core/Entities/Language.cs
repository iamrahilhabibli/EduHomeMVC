using EduHome.Core.Entities.Common;
using System.Collections.Generic;

namespace EduHome.Core.Entities
{
    public class Language : BaseEntity
    {
        public string? LanguageOption { get; set; }

        public ICollection<CourseDetailsLanguage> CourseDetailsLanguages { get; set; }

        public Language()
        {
            CourseDetailsLanguages = new List<CourseDetailsLanguage>();
        }
    }
}
