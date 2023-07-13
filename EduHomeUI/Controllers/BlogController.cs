﻿using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.ViewModels.BlogViewModels;
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
            BlogIndexViewModel viewModel = new BlogIndexViewModel()
            {
                Blogs = await _context.Blogs.ToListAsync()
            };
            return View(viewModel);
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
