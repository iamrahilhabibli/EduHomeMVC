using EduHomeUI.Areas.EHMasterPanel.ViewModels.AssesmentViewModels;

namespace EduHomeUI.Services.Interfaces
{
	public interface IAssesmentService
	{
		Task<bool> CreateAssesmentAsync(AssesmentViewModel assementVM);
	}
}
