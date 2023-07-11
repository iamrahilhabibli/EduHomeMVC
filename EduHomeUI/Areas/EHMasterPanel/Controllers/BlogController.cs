using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.BlogViewModels;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBlogService _blogService;

        public BlogController(AppDbContext context, IBlogService blogService)
        {
            _blogService = blogService;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var blogList = await _blogService.GetAllBlogsAsync();

            var viewModel = new BlogIndexViewModel()
            {
                Blogs = blogList
            };
            return View(viewModel);
        }
    }
}
