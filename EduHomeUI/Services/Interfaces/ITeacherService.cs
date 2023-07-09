using EduHome.Core.Entities;
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
    }
}
