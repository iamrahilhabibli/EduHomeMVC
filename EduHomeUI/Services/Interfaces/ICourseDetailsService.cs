using EduHome.Core.Entities;

namespace EduHomeUI.Services.Interfaces
{
    public interface ICourseDetailsService
    {
        Task<List<CourseDetails>> GetAllCourseDetailsAsync();


    }
}
