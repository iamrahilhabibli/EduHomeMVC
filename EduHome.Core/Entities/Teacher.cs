using EduHome.Core.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Core.Entities
{
    public class Teacher : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public string Position { get; set; }
        public override bool IsDeleted { get; set; }
        public TeacherDetails TeacherDetails { get; set; }
    }
}
