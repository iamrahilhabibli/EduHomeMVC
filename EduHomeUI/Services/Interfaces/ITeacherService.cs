﻿using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.TeacherViewModels;

namespace EduHomeUI.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetAllTeachersAsync();
        Task<bool> CreateTeacherAsync(TeacherCreateViewModel teacherVm);
        Task<bool> GetTeacherById(Guid id);
        Task<Teacher> GetTeacherByIdTeacher(Guid id);
        Task<TeacherDeleteViewModel> MapDeleteVM(Teacher teacher);
        Task<TeacherCreateViewModel> MapCreateVM(Teacher teacher);
        Task<bool> DeleteTeacherById(Guid langId);
        Task<TeacherUpdateViewModel> MapTeacherVM(Teacher teacher);
        Task<bool> UpdateTeacherAsync(Guid courseId, TeacherUpdateViewModel teacher);
        Task<TeacherDetailsViewModel> GetTeacherDetailsViewModelAsync(Guid teacherId);
    }
}
