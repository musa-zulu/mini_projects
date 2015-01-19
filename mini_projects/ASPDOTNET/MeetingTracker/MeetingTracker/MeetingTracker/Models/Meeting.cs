using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetingTracker.Models
{
    public class Meeting
    {
        public int MeetingId { get; set; }
        [Required(ErrorMessage = "Please choose a value from Dropdown cannot be empty!.")]
        [Display(Name = "Meeting Type")]
        public virtual MeetingType MeetingType { get; set; }
        [Required(ErrorMessage = "Name field cannot be empty!.")]
        [MaxLength(50, ErrorMessage = "Description cannot be more than 50 characters in length!.")]
        [Display(Name = "Meeting Description")]
        public string MeetingDescription { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}",ApplyFormatInEditMode = true)]
        [Display(Name = "Meeting Date")]
        public DateTime? MeetingDate { get; set; }
        [Display(Name = "Start Time")]
        public DateTime? StartTime { get; set; }
        [Display(Name = "End Time")]
        public DateTime? EndTime { get; set; }
        public string Location { get; set; }

        public int MeetingTypeId { get; set; }
     

        //public ICollection<Attendees> Attendees{get;set;}
        //  public ICollection<MeetingItem> MeetingItems { get; set; }
       // public virtual ICollection<Person> Persons { get; set; }
        public virtual ICollection<Attendees> Attendeeses { get; set; }
        public virtual ICollection<MeetingItemStatus> MeetingItemStatuses { get; set; }

    }
}