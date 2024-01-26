using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;

namespace Event_Management_Appilcation.Models
{
    public class GroupLeader
    {
        public int GroupLeaderID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public byte[] Profile_image { get; set; }
        [ForeignKey("AdminID")]
        public Admin  AdminID { get; set; }
    }
}
