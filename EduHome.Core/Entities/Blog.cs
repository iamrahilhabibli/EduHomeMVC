using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public int CommentCount { get; set; }

        public Guid BlogDetailsId { get; set; }
        public BlogDetails BlogDetails { get; set; }
    }
}
