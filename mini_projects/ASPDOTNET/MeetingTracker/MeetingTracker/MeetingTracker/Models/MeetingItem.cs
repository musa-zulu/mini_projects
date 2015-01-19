using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetingTracker.Models
{
    public class MeetingItem
    {
        public int MeetingItemId { get; set; }
        public int PersonId { get; set; }
        [Required(ErrorMessage = "Item description field cannot be empty!.")]
        [MaxLength(50, ErrorMessage = "Item description cannot be more than 50 characters in length.")]
        [Display(Name = "Item Description")]
        public string MeetingItemDescription { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; } //this can be nullable
        public string Priority { get; set; }
        public string Status { get; set; }
        [Display(Name = "%Completed")]
        public string PercentageCompleted { get; set; }
        [Display(Name = "Completed Date")]
        public DateTime? CompletedDate { get; set; }  //this can be nullable


        [Required(ErrorMessage = "Please select one item from Dropdown.")]
        [Display(Name = "Assignee")]
        public virtual Person Person { get; set; }

        //  public ICollection<Meeting> Meetings { get; set; }

        public ICollection<MeetingItemStatus> MeetingItemStatuses { get; set; }


    }
}