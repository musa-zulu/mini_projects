using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication.Models
{
    public class UserModels
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Address { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Range(100,10000000)]
        public decimal Salary { get; set; }
    }
}