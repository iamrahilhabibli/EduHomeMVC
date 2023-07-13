using EduHome.DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.ViewComponents
{
	public class HeadViewComponent:ViewComponent
	{
		private readonly AppDbContext _context;
        public HeadViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Dictionary<string,string> setting = await _context.Settings.ToDictionaryAsync(s=>s.Key,s=>s.Value);
            return View(setting);
        }
    }
}
