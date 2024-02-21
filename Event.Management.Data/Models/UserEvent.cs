using System.ComponentModel.DataAnnotations;

namespace Event.Management.Data.Models
{
    public class UserEvent
    {
        [Key]
        public int UserEventID { get; set; }

        public DateTime Registration { get; set; }

        public bool AttendanceStatus { get; set; }
        
        public int? UserID { get; set; } = null;

        public User? User { get; set; }

        public int? SDEventID { get; set; } = null;

        public SDEvent? SDEvent { get; set; }

    }
}
