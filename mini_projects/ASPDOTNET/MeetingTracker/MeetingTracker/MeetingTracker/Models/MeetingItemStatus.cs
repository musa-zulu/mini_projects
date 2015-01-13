

namespace MeetingTracker.Models
{
    public class MeetingItemStatus
    {
        public int MeetingItemStatusId { get; set; }
        public int PersonId { get; set; }
        public int MeetingId { get; set; }
        public int MeetingItemId { get; set; }
        public string CurrentStatus { get; set; }
        public string ActionRequired { get; set; }

        public Person Person { get; set; }
        public Meeting Meeting { get; set; }
        public MeetingItem MeetingItem { get; set; }

    }
}