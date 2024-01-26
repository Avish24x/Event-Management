using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Management_Appilcation.Models
{
    public class Feedback
    {
        public int FeedBackID { get; set; }
        [ForeignKey("EventID")]
        public Event EventID_Event { get; set; }
        [ForeignKey("UserID")]
        public User UserID { get; set; }
        public string DescriptionText  { get; set; }
        public DateOnly DescriptionDate { get; set; }

    }
}
