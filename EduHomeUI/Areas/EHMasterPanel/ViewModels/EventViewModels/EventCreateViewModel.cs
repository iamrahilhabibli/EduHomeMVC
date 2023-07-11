using EduHome.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduHomeUI.Areas.EHMasterPanel.ViewModels.EventViewModels
{
    public class EventCreateViewModel
    {

        public string Title { get; set; }

        public string ImagePath { get; set; }

    
        public string ImageName { get; set; }

        public string Venue { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now.Date;

        public string Description { get; set; }
        public Guid? SpeakerId { get; set; }
        public List<Speaker> Speakers { get; set; }
    }
}
