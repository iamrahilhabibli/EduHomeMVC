using AutoMapper;
using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.TeacherViewModels;

namespace EduHomeUI.Mappers
{
    public class TeacherCreateProfile:Profile
    {
        public TeacherCreateProfile()
        {
            CreateMap<TeacherCreateViewModel,Teacher>().ReverseMap();
            CreateMap<TeacherCreateViewModel, TeacherDetails>().ReverseMap();
        }
    }
}
