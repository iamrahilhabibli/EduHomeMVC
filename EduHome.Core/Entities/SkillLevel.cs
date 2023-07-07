using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities
{
	public class SkillLevel : BaseEntity
    {
        public string? Skill { get; set; }
        CourseDetails? CourseDetail { get; set; }

    }

}
