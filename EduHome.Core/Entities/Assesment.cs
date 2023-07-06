using EduHome.Core.Interfaces;

namespace EduHome.Core.Entities
{
    public class Assesment:IEntity
    {
        public int Id { get; set; }
        public string? AssesmentType { get; set; }
        CourseDetails? CourseDetail { get; set; }
    }
}
