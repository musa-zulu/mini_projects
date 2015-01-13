using System.Collections.Generic;

namespace MeetingTracker.Models
{
    public class MeetingType
    {
        public int MeetingTypeId { get; set; }
        public string MeetingTypeDescription { get; set; }

        public ICollection<Meeting> Meetings { get; set; }
    }
}