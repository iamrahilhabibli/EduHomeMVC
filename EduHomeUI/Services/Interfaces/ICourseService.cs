using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels;

namespace EduHomeUI.Services.Interfaces
{
    public interface ICourseService
    {
        Task<bool> CreateCourseAsync(CourseViewModel courses);
        Task<List<Course>> GetAllCourseAsync();
        Task<bool> GetCourseById(Guid courseId);
        Task<bool> GetCourseDetailById(Guid courseId);
        Task<CourseDetails> GetCourseDetailsAsync(Guid courseId);
        Task<bool> UpdateCourseIsDeleted(Guid courseId, bool isDeleted);
        Task<bool> UpdateCourseDetailIsDeleted(Guid courseDetailId, bool isDeleted);
        Task<bool> DeleteCourseById(Guid courseId);
        Task<Course> GetCourseByIdCourse(Guid courseId);
        Task<CourseViewModel> MapCourseVM(Course course);
        Task<bool> UpdateCourseAsync(Guid courseId, CourseViewModel courses);
        Task<CourseDetailsViewModel> GetCourseDetailsViewModelAsync(Guid courseId);
    }
}
