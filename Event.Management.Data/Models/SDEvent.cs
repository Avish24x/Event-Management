﻿using Event_Management_Appilcation.Models;
using System.ComponentModel.DataAnnotations;

namespace Event.Management.Data.Models
{
    public class SDEvent
    {
        [Key]
        public int SDEventID { get; set; }

        public string EventName { get; set; }

        public string Description { get; set; }

        public string Starting_Time { get; set; }

        public string Ending_Time { get; set; }

        public string Objective { get; set; }

        public string Status { get; set; }

        public string Type { get; set; }

        public string Location { get; set; }

        // Replace IFormFile with byte[] if you intend to store the files in the database
        //[NotMapped] // This ensures the property is not mapped to the database
        public string? Attachment { get; set; }

        //[NotMapped]
        public string? Event_Image { get; set; }

        public string Sponsors { get; set; }

        public string Outcome { get; set; }

        public int Capacity { get; set; }

        public int? GroupID { get; set; } = null;

        public GroupTable? groupTable { get; set; }  

        public int? UserId { get; set; } = null;

        // Navigation properties
        public ICollection<UserEvent>? UserEvents { get; set; }

        public ICollection<GroupTable>? GroupTables { get; set; }

        public ICollection<Feedback>? Feedbacks { get; set; }

    }
}
