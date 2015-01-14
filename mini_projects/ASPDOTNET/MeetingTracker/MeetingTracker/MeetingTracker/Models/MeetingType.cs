using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetingTracker.Models
{
    public class MeetingType
    {
        public int MeetingTypeId { get; set; }
         [Display(Name = "Meeting Type Description")]
        public string MeetingTypeDescription { get; set; }

        public ICollection<Meeting> Meetings { get; set; }
    }
}