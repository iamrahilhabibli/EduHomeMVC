using EduHome.Core.Entities;

namespace EduHomeUI.ViewModels.BlogViewModels
{
    public class BlogIndexViewModel
    {
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<BlogDetails> BlogDetails { get; set; }    
    }
}
