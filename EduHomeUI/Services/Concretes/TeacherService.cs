using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.TeacherViewModels;
using EduHomeUI.Services.Interfaces;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace EduHomeUI.Services.Concretes
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

        public async Task<bool> CreateTeacherAsync(TeacherCreateViewModel teacherVm)
        {
            if (teacherVm is null) return false;

            Teacher teacher = _mapper.Map<Teacher>(teacherVm);
            teacher.TeacherDetails = _mapper.Map<TeacherDetails>(teacherVm);
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Teacher>> GetAllTeachersAsync()
        {
            return await _context.Teachers.ToListAsync();
        }
    }
}
