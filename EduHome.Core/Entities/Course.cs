using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Core.Entities
{
    public class Course:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public CourseDetails Details { get; set; }
        [ForeignKey("CourseCategory")]
        public int CourseCategoryId { get; set; }
        public CourseCategory CourseCatagory { get; set; }
    }
}
