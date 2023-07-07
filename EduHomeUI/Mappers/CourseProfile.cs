using AutoMapper;
using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseViewModels;

namespace EduHomeUI.Mappers
{
    public class CourseProfile:Profile
	{
        public CourseProfile()
        {
            CreateMap<CourseViewModel, Course>().ReverseMap();
        }
    }
}
