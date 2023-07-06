using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities
{
    public class Course : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public string? ImageName { get; set; }
        public CourseDetails? Details { get; set; }
        public int CourseCategoryId { get; set; }
        public CourseCategory? CourseCategory { get; set; }
    }
}
