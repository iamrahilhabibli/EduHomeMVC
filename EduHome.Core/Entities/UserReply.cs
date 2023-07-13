using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities
{
    public class UserReply
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
