using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Services.Interfaces
{
    public class TeacherService : ITeacherService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TeacherService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<List<Teacher>> GetAllTeachersAsync()
        {
            return await _context.Teachers.ToListAsync();
        }
    }
}
