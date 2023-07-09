using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.TeacherViewModels;

namespace EduHomeUI.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetAllTeachersAsync();
        Task<bool> CreateTeacherAsync(TeacherCreateViewModel teacherVm);
    }
}
