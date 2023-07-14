using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities
{
    public class Subscribers:BaseEntity
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public override bool IsDeleted { get; set; }
    }
}
