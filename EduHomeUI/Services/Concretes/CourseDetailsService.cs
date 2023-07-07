using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Services.Concretes
{
    public class CourseDetailsService : ICourseDetailsService
    {
        private readonly AppDbContext _context;

        public CourseDetailsService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<CourseDetails>> GetAllCourseDetailsAsync()
        {
            return await _context.courseDetails.ToListAsync();
        }
    }
}
