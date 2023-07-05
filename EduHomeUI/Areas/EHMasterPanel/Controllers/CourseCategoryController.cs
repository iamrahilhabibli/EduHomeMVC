using AutoMapper;
using EduHome.DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
	[Area("EHMasterPanel")]
	public class CourseCategoryController : Controller
	{
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;
		public CourseCategoryController(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public async Task<IActionResult> Index()
		{
			return View(await _context.courseCategories.ToListAsync());
		}
		public IActionResult Create()
		{
			return View();
		}
	}
}
