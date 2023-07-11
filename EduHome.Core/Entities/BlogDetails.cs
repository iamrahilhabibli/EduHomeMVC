using EduHome.Core.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Core.Entities
{
    public class BlogDetails:BaseEntity
    {
        public string Description { get; set; }
        public Blog Blog { get; set; }
    }
}
