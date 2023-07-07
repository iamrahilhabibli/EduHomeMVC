using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.ViewModels;

namespace EduHomeUI.Services.Interfaces
{
    public interface ICourseService
    {
        Task<bool> CreateCourseAsync(CourseViewModel courses);
        Task<List<Course>> GetAllCourseAsync();
    }
}
