using EduHome.DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.ViewComponents
{
    public class SectionlogoViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        public SectionlogoViewComponent(AppDbContext context)
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
