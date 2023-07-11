using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
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
        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            return await _context.Blogs.ToListAsync();
        }
    }
}
