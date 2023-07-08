namespace EduHome.Core.Entities
{

    public class CourseDetailsSkillLevel
    {
        public Guid Id { get; set; }
        public Guid CourseDetailsId { get; set; }
        public CourseDetails CourseDetails { get; set; }

        public Guid SkillLevelId { get; set; }
        public SkillLevel SkillLevel { get; set; }
    }


}
