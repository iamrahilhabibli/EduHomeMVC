using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.BlogViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels;
using EduHomeUI.Services.Concretes;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    [Area("EHMasterPanel")]
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
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(BlogCreateViewModel blogVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _blogService.CreateBlogAsync(blogVm)) return BadRequest();
            TempData["Success"] = "Blog Created Successfully!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await _blogService.GetBlogById(id))
            {
                return NotFound();
            }

            var blog = await _blogService.GetBlogByIdBlog(id);

            var viewModel = new BlogDeleteViewModel
            {
                Title = blog.Title,
                AuthorName = blog.AuthorName,
                ImagePath = blog.ImagePath,
            };

            return View(viewModel);
        }

    }
}
