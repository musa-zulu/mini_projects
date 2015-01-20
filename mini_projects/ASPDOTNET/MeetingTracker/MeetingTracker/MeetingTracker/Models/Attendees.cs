namespace MeetingTracker.Models
{
    public class Attendees
    {
        public int AttendeesId { get; set; }
        public int MeetingId { get; set; }
        public int PersonId { get; set; }

        public virtual Meeting Meeting { get; set; }
        public virtual Person Person { get; set; }
    }
}