using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities
{
    public class Notice:BaseEntity
    {
        public override bool IsDeleted { get; set; }
        public string Description { get; set; }
    }
}
