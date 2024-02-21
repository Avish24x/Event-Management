using System.ComponentModel.DataAnnotations.Schema;

namespace Event.Management.Data.Models
{
    public class Feedback
    {
        public int FeedBackID { get; set; }

        public int? EventID { get; set; } = null;

        public SDEvent? Event { get; set; }


        public int? UserID { get; set; } = null;

        public User? User { get; set; }

        
        public string? DescriptionText  { get; set; }

        public DateTime DescriptionDate { get; set; }


    }
}
