

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingTracker.Models
{
    public class MeetingItemStatus
    {
        [Key]
        public int MeetingItemStatusId { get; set; }
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        [ForeignKey("Meeting")]
        public int MeetingId { get; set; }
        [ForeignKey("MeetingItem")]
        public int MeetingItemId { get; set; }
        [Display(Name = "Current Status")]
        public string CurrentStatus { get; set; }
        [Display(Name = "Action Required")]
        public string ActionRequired { get; set; }
        [Display(Name = "Date Updated")]
        public DateTime? DateUpdated { get; set; }
       
        
        
        
        [Display(Name="Responsible Person")]
        public Person Person { get; set; }
        public Meeting Meeting { get; set; }
        [Display(Name = "Meeting Item")]
        public MeetingItem MeetingItem { get; set; }

    }
}