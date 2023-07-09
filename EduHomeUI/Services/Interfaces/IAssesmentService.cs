using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.AssesmentViewModels;

namespace EduHomeUI.Services.Interfaces
{
	public interface IAssesmentService
	{
		Task<bool> CreateAssesmentAsync(AssesmentViewModel assementVM);
		Task<List<Assesment>> GetAllAssesment();
		Task<bool> GetAssesmentById(Guid assesId);
		Task<Assesment> GetAssesmentByIdAssesment(Guid assesId);
		Task<bool> DeleteAssesmentById(Guid assesId);
	}
}
