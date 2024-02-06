using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Management_Appilcation.Models
{
    public class Feedback
    {
        public int FeedBackID { get; set; }

        
        
        public int EventID { get; set; }
        public Event Event { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }
        
        public string DescriptionText  { get; set; }
        public DateTime DescriptionDate { get; set; }

    }
}
