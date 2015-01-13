using System;
using System.Collections.Generic;

namespace MeetingTracker.Models
{
    public class MeetingItem
    {
        public int MeetingItemId { get; set; }
        public string MeetingItemDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }
        public string PercentageCompleted { get; set; }

        public ICollection<MeetingItemStatus> MeetingItemStatuses { get; set; }

    }
}