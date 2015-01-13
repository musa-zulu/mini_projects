using System.Data.Entity;

namespace MeetingTracker.Models
{
    public class MeetingContext : DbContext
    {
        public MeetingContext() : base("name=MeetingContext")
        {
        }

        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingItem> MeetingItems { get; set; }
        public DbSet<MeetingItemStatus> MeetingItemStatuses { get; set; }
        public DbSet<MeetingType> MeetingTypes { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}