using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Services.Configuration;

namespace MeetingTracker.Models
{
    public class MeetingItem
    {
        public int MeetingItemId { get; set; }
        [Display(Name = "Item Description")]
        public string MeetingItemDescription { get; set; }
        public string Priority { get; set; }
            [Display(Name = "% Completed")]
        public string PercentageCompleted { get; set; }
        public string Duration { get; set; }


        public ICollection<MeetingItemStatus> MeetingItemStatuses { get; set; }


    }
}