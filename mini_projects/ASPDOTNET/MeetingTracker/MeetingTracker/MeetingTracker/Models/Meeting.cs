using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetingTracker.Models
{
    public class Meeting
    {
        public int MeetingId { get; set; }
        [Display(Name = "Meeting Type")]
        public MeetingType MeetingType { get; set; }
        [Display(Name = "Meeting Description")]
        public string MeetingDescription { get; set; }
        [Display(Name = "Meeting Date")]
        public DateTime MeetingDate { get; set; }
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
        public string Location { get; set; }

        public int MeetingTypeId { get; set; }
        public ICollection<MeetingItemStatus> MeetingItemStatuses { get; set; }
    }
}