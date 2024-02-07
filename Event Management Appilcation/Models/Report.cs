using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Event_Management_Appilcation.Models
{
    public class Report
    {
        [Key]
        public int ReportID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime DateGenerated { get; set; }

        // Add properties for report data
        // For example:
        public ICollection<Event> Events { get; set; }
        public string Description { get; set; }
        // Add other properties as needed...
    }
}
