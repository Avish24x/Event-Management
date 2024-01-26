using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Management_Appilcation.Models
{
    public class UserEvent
    {
        public int UserEventID { get; set; }
        public DateOnly Registration { get; set; }
        public Boolean AttendanceStatus { get; set; }
        [ForeignKey("UserID")]
        public User UserID { get; set; }

        [ForeignKey("EventID")]
        public Event EventID { get; set; }
    }
}
