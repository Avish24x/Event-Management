using Microsoft.AspNetCore.Identity;

namespace Event_Management_Appilcation.Models
{
    public class GroupLeader
    {
        public int GroupLeaderID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte[] Profile_image { get; set; }
        public string Email { get; set; }
        
        public int GroupID { get; set; }
        public GroupTable Group { get; set; }

        // Navigation property for AdminGroupLeaders
        public ICollection<AdminGroupLeader> AdminGroupLeaders { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
