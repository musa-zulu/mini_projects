
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetingTracker.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int? Phone { get; set; }

        public ICollection<MeetingItemStatus> MeetingItemStatuses { get; set; }


 

    }
}