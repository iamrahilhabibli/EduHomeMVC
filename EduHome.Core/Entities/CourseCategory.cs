using System.ComponentModel.DataAnnotations;
using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities;

public class CourseCategory:BaseEntity
{
    public int Id { get; set; }
    [Required,MaxLength(30)]
    public string Category { get; set; }
    public ICollection<Course> Courses { get; set; }
}
