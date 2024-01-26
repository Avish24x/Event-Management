using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Management_Appilcation.Models
{
    public class TeamMember
    {
        public int TeamMemberID { get; set; }
        public string Description { get; set; }
        public char Password { get; set; }
        public char email { get; set; }
        public byte[] Profile_Image { get; set; }

        [ForeignKey("GroupLeaderID")]
        public GroupLeader GroupLeaderID { get; set; }
    }
}
