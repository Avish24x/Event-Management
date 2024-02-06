using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Management_Appilcation.Models
{
    public class UserEvent
    {
        public int UserEventID { get; set; }
        public DateTime Registration { get; set; }
        public bool AttendanceStatus { get; set; }
        
        public int UserID { get; set; }
        public User User { get; set; }

        public int EventID { get; set; }
        public Event Event { get; set; }
    }
}
