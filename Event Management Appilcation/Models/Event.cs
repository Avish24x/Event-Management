using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace Event_Management_Appilcation.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string Description { get; set; }
        public TimeOnly Starting_Time { get; set; }
        public TimeOnly Ending_Time { get; set; }
        public string  objective { get; set; }
        public Boolean Status { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public byte[] Attachment{ get; set; }
        public byte[] Event_Image { get; set; }
        public string Sponsors { get; set; }
        public int Rating { get; set; }
        public string Outcome { get; set; }
        public int Capacity { get; set; }
        [ForeignKey("GroupLeaderId")]
        public Event GroupLeaderID { get; set; }
        [ForeignKey("TeamMemberID")]
        public TeamMember TeamMemberID { get; set; }

        [ForeignKey("UserID")]
        public User UserID { get; set; }
    }
}
