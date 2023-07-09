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

        public async Task<bool> GetTeacherById(Guid id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher is null) return false;
            return true;
        }
        public async Task<Teacher> GetTeacherByIdTeacher(Guid id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public async Task<TeacherDeleteViewModel> MapDeleteVM(Teacher teacher)
        {
            return await Task.FromResult(_mapper.Map<TeacherDeleteViewModel>(teacher));
        }
        public async Task<TeacherCreateViewModel> MapCreateVM(Teacher teacher)
        {
            return await Task.FromResult(_mapper.Map<TeacherCreateViewModel>(teacher));
        }
        public async Task<bool> DeleteTeacherById(Guid langId)
        {
            var teacher = await _context.Teachers.FindAsync(langId);

            if (teacher is null)
            {
                return false;
            }

            teacher.IsDeleted = true;
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
