using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Event_Management_Appilcation.Models
{
    public class Event
    {
        public int EventID { get; set; }

        public string Description { get; set; }

        public DateTime Starting_Time { get; set; }

        public DateTime Ending_Time { get; set; }

        public string Objective { get; set; }

        public bool Status { get; set; }

        public string Type { get; set; }

        public string Location { get; set; }

        // Replace IFormFile with byte[] if you intend to store the files in the database
        [NotMapped] // This ensures the property is not mapped to the database
        public IFormFile Attachment { get; set; }

        [NotMapped]
        public IFormFile Event_Image { get; set; }

        public string Sponsors { get; set; }

        public int Rating { get; set; }

        public string Outcome { get; set; }

        public int Capacity { get; set; }

        public int GroupLeaderID { get; set; }

        public int TeamMemberID { get; set; }

        // Navigation properties
        public GroupLeader GroupLeader { get; set; }

        public TeamMember TeamMember { get; set; }

        public ICollection<UserEvent> UserEvents { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
