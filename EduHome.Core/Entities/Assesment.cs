using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities
{
	public class Assesment:BaseEntity
    {
        public string? AssesmentType { get; set; }
        public CourseDetails CourseDetails { get; set; }
    }
}
