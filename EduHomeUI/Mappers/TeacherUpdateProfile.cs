using AutoMapper;
using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.TeacherViewModels;

namespace EduHomeUI.Mappers
{
    public class TeacherUpdateProfile:Profile
    {
        public TeacherUpdateProfile()
        {
            CreateMap<TeacherUpdateViewModel, Teacher>().ReverseMap();
            CreateMap<TeacherUpdateViewModel, TeacherDetails>().ReverseMap();
        }
    }
}
