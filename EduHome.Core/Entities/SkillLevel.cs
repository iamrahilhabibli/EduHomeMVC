using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities
{
    public class SkillLevel : BaseEntity
    {
        public string? Skill { get; set; }
        public CourseDetails CourseDetails { get; set; }
    }
}