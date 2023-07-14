using EduHome.DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EduHomeUI.Areas.EHMasterPanel.ViewComponents
{
    public class HeadadminViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public HeadadminViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Dictionary<string, string> setting = await _context.Settings.ToDictionaryAsync(s => s.Key, s => s.Value);
            return View(setting);
        }
    }
}
