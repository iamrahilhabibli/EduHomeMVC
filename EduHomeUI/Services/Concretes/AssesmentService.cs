using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.AssesmentViewModels;
using EduHomeUI.Services.Interfaces;

namespace EduHomeUI.Services.Concretes
{
	public class AssesmentService : IAssesmentService
	{
		private readonly AppDbContext _context;

        public AssesmentService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateAssesmentAsync(AssesmentViewModel assementVM)
		{
			if (assementVM is null)
			{
				return false;
			}
			Assesment newAssesment = new()
			{
				Id = Guid.NewGuid(),
				AssesmentType = assementVM.AssesmentType,
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
			};
			await _context.Assesments.AddAsync(newAssesment);
			_context.SaveChanges();
			return true;
		}
	}
}
