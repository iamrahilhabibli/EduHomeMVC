using EduHome.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduHomeUI.Areas.EHMasterPanel.ViewModels.EventViewModels
{
    public class EventCreateViewModel
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ImagePath is required.")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "ImageName is required.")]
        public string ImageName { get; set; }

        [Required(ErrorMessage = "Venue is required.")]
        public string Venue { get; set; }

        [Required(ErrorMessage = "StartTime is required.")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "EndTime is required.")]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now.Date;

        public string Description { get; set; }
        public Guid? SpeakerId { get; set; }

        public List<Speaker> Speakers { get; set; }
    }
}
