using EduHome.Core.Interfaces;

namespace EduHome.Core.Entities
{
    public class SkillLevel : IEntity
    {
        public int Id { get; set; }
        public string? Skill { get; set; }
        CourseDetails? CourseDetail { get; set; }

    }

}
