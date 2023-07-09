using EduHome.Core.Entities;

namespace EduHomeUI.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetAllTeachersAsync();
    }
}
