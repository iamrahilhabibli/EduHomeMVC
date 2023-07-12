using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.AppUserViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Areas.EHMasterPanel.Controllers
{
    [Area("EHMasterPanel")]
    public class AppUserController : Controller
    {
        private readonly AppDbContext _context;
        public AppUserController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            AppUserIndexViewModel model = new AppUserIndexViewModel()
            {
                appUsers = await _context.Users.ToListAsync()
            };

            return View(model);
        }

    }
}
