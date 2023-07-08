using EduHome.Core.Entities.Common;
using System.Collections.Generic;

namespace EduHome.Core.Entities
{
    public class SkillLevel : BaseEntity
    {
        public string? Skill { get; set; }

        public ICollection<CourseDetailsSkillLevel> CourseDetailsSkillLevels { get; set; }

        public SkillLevel()
        {
            CourseDetailsSkillLevels = new List<CourseDetailsSkillLevel>();
        }
    }
}
