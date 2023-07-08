using AutoMapper;
using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels;

namespace EduHomeUI.Mappers
{
    public class CourseCourseVMProfile:Profile
    {
        public CourseCourseVMProfile()
        {
            CreateMap<Course, CourseViewModel>().ReverseMap();
        }
    }
}
