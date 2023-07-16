using EduHome.Core.Entities;
using System.Collections.Generic;

namespace EduHomeUI.Areas.EHMasterPanel.ViewModels.EnrolledStudentsViewModels
{
    public class EnrolledStudentIndexViewModel
    {
        public IEnumerable<ConfirmedStudents> ConfirmedStudents { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
