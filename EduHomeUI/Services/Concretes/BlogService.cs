using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.BlogViewModels;
using EduHomeUI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Services.Concretes
{
    public class BlogService : IBlogService
    {
        private readonly AppDbContext _context;

        public BlogService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateBlogAsync(BlogCreateViewModel blogVm)
        {
            if (blogVm is null)
                return false;

            var blog = new Blog
            {
                Title = blogVm.Title,
                AuthorName = blogVm.AuthorName,
                ImagePath = blogVm.ImagePath,
                ImageName = blogVm.ImageName,
                CommentCount = blogVm.CommentCount,
                BlogDetails = new BlogDetails
                {
                    Description = blogVm.Description
                }
            };

            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            return await _context.Blogs.ToListAsync();
        }
    }
}
