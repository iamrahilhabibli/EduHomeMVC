using EduHome.Core.Entities.Common;
using System.Collections.Generic;

namespace EduHome.Core.Entities
{
    public class Language : BaseEntity
    {
        public string? LanguageOption { get; set; }
        public ICollection<CourseDetails> CourseDetails { get; set; }
    }
}
