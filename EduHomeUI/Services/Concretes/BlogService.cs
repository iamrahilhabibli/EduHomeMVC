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

            var blogDetails = new BlogDetails
            {
                Description = blogVm.Description
            };

            var blog = new Blog
            {
                Title = blogVm.Title,
                AuthorName = blogVm.AuthorName,
                ImagePath = blogVm.ImagePath,
                ImageName = blogVm.ImageName,
                CommentCount = blogVm.CommentCount,
                BlogDetails = blogDetails
            };

            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            return await _context.Blogs.ToListAsync();
        }
        public async Task<bool> GetBlogById(Guid blogId)
        {
            var blog = await _context.Blogs.FindAsync(blogId);
            if (blog is null) return false;
            return true;
        }
        public async Task<Blog> GetBlogByIdBlog(Guid blogId)
        {
            return await _context.Blogs.FindAsync(blogId);
        }

        public async Task<bool> GetBlogDetailById(Guid blogId)
        {
            var blog = await _context.Blogs.FindAsync(blogId);
            if (blog is null || blog.BlogDetailsId == null) return false;

            var blogDetails = await _context.BlogDetails.FindAsync(blog.BlogDetailsId);
            if (blogDetails is null) return false;

            return true;
        }


        public async Task<bool> UpdateBlogDetailIsDeleted(Guid blogId, bool isDeleted)
        {
            var blog = await _context.Blogs.FindAsync(blogId);
            if (blog is null) return false;

   
            var blogDetailsId = blog.BlogDetailsId;

            var blogDetails = await _context.BlogDetails.FindAsync(blogDetailsId);
            if (blogDetails is null) return false;

            blogDetails.IsDeleted = isDeleted;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateBlogIsDeleted(Guid blogId, bool isDeleted)
        {
            var blog = await _context.Blogs.FindAsync(blogId);
            if (blog is null) return false;

            blog.IsDeleted = isDeleted;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
