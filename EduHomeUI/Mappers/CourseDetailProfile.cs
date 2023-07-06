using AutoMapper;
using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.ViewModels;

namespace EduHomeUI.Mappers
{
    public class CourseDetailProfile:Profile
    {
        public CourseDetailProfile()
        {
            CreateMap<CourseViewModel, CourseDetails>().ReverseMap();
        }
    }
}
