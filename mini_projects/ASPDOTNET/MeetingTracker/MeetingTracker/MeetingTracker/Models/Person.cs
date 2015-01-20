using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetingTracker.Models
{
    public class Person
    {
      
        public int PersonId { get; set; }
        [Required(ErrorMessage = "Name field cannot be empty!.")]
        [MaxLength(15, ErrorMessage = "First Name cannot be more than 30 characters in length.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Name field cannot be empty!.")]
        [MaxLength(15, ErrorMessage = "Last Name cannot be more than 30 characters in length.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your Email address")]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "Please enter a valid email address")]
      
        public string Email { get; set; }
        [Required(ErrorMessage = "Name field cannot be empty!.")]
        [MaxLength(15, ErrorMessage = "Name cannot be more than 30 characters in length.")]
        public string Address { get; set; }
        [RegularExpression(@"\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})", ErrorMessage = "Please provide a valide phone number.")]
        [MaxLength(10, ErrorMessage = "Phone number cannot be more than 10 characters.")]
        public string Phone { get; set; }



        // public int MeetingId { get; set; }
        public virtual ICollection<Attendees> Attendeeses { get; set; }
        public virtual ICollection<MeetingItem> MeetingItems { get; set; }
        public virtual ICollection<MeetingItemStatus> MeetingItemStatuses { get; set; }




    }
}