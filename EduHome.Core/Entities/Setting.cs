using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities
{
    public class Setting:BaseEntity
    {
        public string Key { get; set; } = null!;
        public string Value { get; set; } = null!;
        public override bool IsDeleted { get; set; }
    }
}
