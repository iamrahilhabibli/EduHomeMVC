using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels;
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
        public async Task<TeacherUpdateViewModel> MapTeacherVM(Teacher teacher)
        {
            var teacherWithDetails = await _context.Teachers
                .Include(t => t.TeacherDetails)
                .FirstOrDefaultAsync(t => t.Id == teacher.Id);

            if (teacherWithDetails == null)
            {
                return null;
            }

            var viewModel = new TeacherUpdateViewModel
            {
                Name = teacherWithDetails.Name,
                Surname = teacherWithDetails.Surname,
                ImagePath = teacherWithDetails.ImagePath,
                ImageName = teacherWithDetails.ImageName,
                Position = teacherWithDetails.Position,
                Description = teacherWithDetails.TeacherDetails?.Description,
                Email = teacherWithDetails.TeacherDetails?.Email,
                PhoneNumber = teacherWithDetails.TeacherDetails?.PhoneNumber,
                SkypeAddress = teacherWithDetails.TeacherDetails?.SkypeAddress,
                LanguageSkills = teacherWithDetails.TeacherDetails?.LanguageSkills ?? 0,
                TeamLeaderSkills = teacherWithDetails.TeacherDetails?.TeamLeaderSkills ?? 0,
                DevelopmentSkills = teacherWithDetails.TeacherDetails?.DevelopmentSkills ?? 0,
                Design = teacherWithDetails.TeacherDetails?.Design ?? 0,
                Innovation = teacherWithDetails.TeacherDetails?.Innovation ?? 0,
                Communication = teacherWithDetails.TeacherDetails?.Communication ?? 0
            };

            return viewModel;
        }

        public async Task<bool> UpdateTeacherAsync(Guid teacherId, TeacherUpdateViewModel teacher)
        {
            Teacher existingTeacher = await _context.Teachers.Include(t => t.TeacherDetails).FirstOrDefaultAsync(t => t.Id == teacherId);
            if (existingTeacher == null)
            {
                return false;
            }

            existingTeacher.Name = teacher.Name;
            existingTeacher.Surname = teacher.Surname;
            existingTeacher.ImagePath = teacher.ImagePath;
            existingTeacher.ImageName = teacher.ImageName;
            existingTeacher.Position = teacher.Position;

            if (existingTeacher.TeacherDetails != null)
            {
                existingTeacher.TeacherDetails.Description = teacher.Description;
                existingTeacher.TeacherDetails.Email = teacher.Email;
                existingTeacher.TeacherDetails.PhoneNumber = teacher.PhoneNumber;
                existingTeacher.TeacherDetails.SkypeAddress = teacher.SkypeAddress;
                existingTeacher.TeacherDetails.LanguageSkills = teacher.LanguageSkills;
                existingTeacher.TeacherDetails.TeamLeaderSkills = teacher.TeamLeaderSkills;
                existingTeacher.TeacherDetails.DevelopmentSkills = teacher.DevelopmentSkills;
                existingTeacher.TeacherDetails.Design = teacher.Design;
                existingTeacher.TeacherDetails.Innovation = teacher.Innovation;
                existingTeacher.TeacherDetails.Communication = teacher.Communication;

                _context.Entry(existingTeacher.TeacherDetails).State = EntityState.Modified;
            }
            else
            {
                TeacherDetails newDetails = new TeacherDetails
                {
                    Description = teacher.Description,
                    Email = teacher.Email,
                    PhoneNumber = teacher.PhoneNumber,
                    SkypeAddress = teacher.SkypeAddress,
                    LanguageSkills = teacher.LanguageSkills,
                    TeamLeaderSkills = teacher.TeamLeaderSkills,
                    DevelopmentSkills = teacher.DevelopmentSkills,
                    Design = teacher.Design,
                    Innovation = teacher.Innovation,
                    Communication = teacher.Communication
                };

                existingTeacher.TeacherDetails = newDetails;
                _context.TeacherDetails.Add(newDetails);
            }

            _context.Entry(existingTeacher).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<TeacherDetailsViewModel> GetTeacherDetailsViewModelAsync(Guid teacherId)
        {
            var teacherDetails = await _context.Teachers
                .Include(t => t.TeacherDetails)
                .FirstOrDefaultAsync(t => t.Id == teacherId);

            if (teacherDetails == null)
            {
                return null;
            }

            var teacherDetailsViewModel = new TeacherDetailsViewModel
            {
                Name = teacherDetails.Name,
                Surname = teacherDetails.Surname,
                ImagePath = teacherDetails.ImagePath,
                Position = teacherDetails.Position,
                Description = teacherDetails.TeacherDetails?.Description,
                Email = teacherDetails.TeacherDetails?.Email,
                PhoneNumber = teacherDetails.TeacherDetails?.PhoneNumber,
                SkypeAddress = teacherDetails.TeacherDetails?.SkypeAddress,
                LanguageSkills = teacherDetails.TeacherDetails?.LanguageSkills ?? 0,
                TeamLeaderSkills = teacherDetails.TeacherDetails?.TeamLeaderSkills ?? 0,
                DevelopmentSkills = teacherDetails.TeacherDetails?.DevelopmentSkills ?? 0,
                Design = teacherDetails.TeacherDetails?.Design ?? 0,
                Innovation = teacherDetails.TeacherDetails?.Innovation ?? 0,
                Communication = teacherDetails.TeacherDetails?.Communication ?? 0
            };

            return teacherDetailsViewModel;
        }

    }
}
