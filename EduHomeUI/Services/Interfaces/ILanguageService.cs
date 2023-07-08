using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.LanguageViewModels;

namespace EduHomeUI.Services.Interfaces
{
	public interface ILanguageService
	{
		Task<bool> CreateLanguageAsync(LanguageViewModel languageVm);
		Task<List<Language>> GetAllLanguages();
	}
}
