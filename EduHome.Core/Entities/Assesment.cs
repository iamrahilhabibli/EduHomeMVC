using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities
{
	public class Assesment:BaseEntity
    {
        public string? AssesmentType { get; set; }

        public ICollection<CourseDetailsAssesment> CourseDetailsAssesment { get; set; }

        public Assesment()
        {
            CourseDetailsAssesment = new List<CourseDetailsAssesment>();
        }
    }
}
