using EduHome.Core.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Core.Entities
{
    public class Course : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public string? ImageName { get; set; }
        public CourseDetails? Details { get; set; }
        public Guid CourseCategoryId { get; set; }
        public CourseCategory? CourseCategory { get; set; }
    }
}
