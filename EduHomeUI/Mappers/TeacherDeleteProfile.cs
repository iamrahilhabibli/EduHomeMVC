using AutoMapper;
using EduHome.Core.Entities;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.TeacherViewModels;

namespace EduHomeUI.Mappers
{
    public class TeacherDeleteProfile:Profile
    {
        public TeacherDeleteProfile()
        {
            CreateMap<Teacher, TeacherDeleteViewModel>().ReverseMap();
        }
    }
}
