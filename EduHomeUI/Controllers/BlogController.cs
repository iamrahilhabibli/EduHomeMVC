using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels.BlogViewModels;
using EduHomeUI.ViewModels.SubscribeViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            BlogCompositeViewModel model = new BlogCompositeViewModel()
            {
                BlogIndex = new BlogIndexViewModel()
                {
                    Blogs = await _context.Blogs.ToListAsync()
                },
                SubscriberCreate = new SubscriberCreateViewModel()
            };
            return View(model);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            Blog blog = await _context.Blogs.FindAsync(id);

            if (blog == null)
            {
                return NotFound();
            }

            BlogIndexViewModel blogVm = new()
            {
                Blogs = new List<Blog> { blog },
                BlogDetails = await _context.BlogDetails.ToListAsync()
            };
            return View(blogVm);
        }
    }
}
