using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.AssesmentViewModels;
using EduHomeUI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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
				AssesmentType = assementVM.AssesmentType,
			};
			await _context.Assesments.AddAsync(newAssesment);
			_context.SaveChanges();
			return true;
		}

        public async Task<bool> DeleteAssesmentById(Guid assesId)
        {
            var assesmments = await _context.Assesments.FindAsync(assesId);

            if (assesmments is null)
            {
                return false;
            }

            assesmments.IsDeleted = true;
            _context.Assesments.Update(assesmments);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Assesment>> GetAllAssesment()
        {
			return await _context.Assesments.ToListAsync();
        }

        public async Task<bool> GetAssesmentById(Guid assesId)
        {
			var assesment = await _context.Assesments.FindAsync(assesId);
			if (assesment is null) return false;
			return true;
        }
		public async Task<Assesment> GetAssesmentByIdAssesment(Guid assesId)
		{
			return await _context.Assesments.FindAsync(assesId);
		}
    }
}
