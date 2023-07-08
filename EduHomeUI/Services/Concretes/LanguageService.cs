using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.LanguageViewModels;
using EduHomeUI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Services.Concretes
{
	public class LanguageService : ILanguageService
	{
		private readonly AppDbContext _context;

		public LanguageService(AppDbContext context)
		{
			_context = context;
		}
		public async Task<bool> CreateLanguageAsync(LanguageViewModel languageVm)
		{
			if (languageVm is null) return false;
			Language newLanguage = new()
			{
				Id = Guid.NewGuid(),
				LanguageOption = languageVm.LanguageOption,
				IsDeleted = false
			};
			_context.Languages.Add(newLanguage);
			await _context.SaveChangesAsync();
			return true;
		}

        public async Task<List<Language>> GetAllLanguages()
        {
            return await _context.Languages.ToListAsync();
        }
    }
}
