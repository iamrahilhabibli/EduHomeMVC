using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities
{
    public class BlogDetails:BaseEntity
    {
        public string Description { get; set; }
        public Blog Blog { get; set; }
    }
}
