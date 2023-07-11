using EduHome.Core.Entities;
using System.ComponentModel.DataAnnotations;

public class EventUpdateViewModel
{

    public string Title { get; set; }


    public string ImagePath { get; set; }

    public string ImageName { get; set; }

    public string Venue { get; set; }


    public DateTime StartTime { get; set; }



    public DateTime EndTime { get; set; }

    public DateTime Date { get; set; } = DateTime.Now.Date;

    public string Description { get; set; }

    public Guid? SpeakerId { get; set; }

    public Speaker? Speaker { get; set; }

    public List<Speaker>? Speakers { get; set; }
}
