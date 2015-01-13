using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetingTracker.Models
{
    public class Meeting
    {
        public int MeetingId { get; set; }
       
        public MeetingType MeetingType { get; set; }
        public string MeetingDescription { get; set; }
        public DateTime MeetingDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }


        public int MeetingTypeId { get; set; }
        public ICollection<MeetingItemStatus> MeetingItemStatuses { get; set; }
    }
}