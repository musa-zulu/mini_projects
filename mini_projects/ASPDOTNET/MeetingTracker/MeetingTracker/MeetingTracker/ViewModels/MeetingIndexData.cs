using System.Collections.Generic;
using MeetingTracker.Models;

namespace MeetingTracker.ViewModels
{
    public class MeetingIndexData
    {
        public IEnumerable<Meeting> Meetings { get; set; }
        public IEnumerable<MeetingItemStatus> MeetingItemStatuses { get; set; }
        public IEnumerable<MeetingItem> MeetingItems { get; set; }
    }
}