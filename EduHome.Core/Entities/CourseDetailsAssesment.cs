using System;

namespace EduHome.Core.Entities
{
    public class CourseDetailsAssesment
    {
        public Guid CourseDetailsId { get; set; }
        public CourseDetails CourseDetails { get; set; }

        public Guid AssesmentId { get; set; }
        public Assesment Assesment { get; set; }
    }
}
