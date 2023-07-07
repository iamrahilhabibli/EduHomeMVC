using EduHome.Core.Entities;

namespace EduHomeUI.Services.Interfaces
{
    public interface ICourseDetails
    {
        Task<List<CourseDetails>> GetAllCourseDetails();
    }
}
