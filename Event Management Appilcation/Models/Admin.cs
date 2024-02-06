using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Event_Management_Appilcation.Models
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte[] Profile_image { get; set; }
        public string Email { get; set; }

        // Navigation property for AdminGroupLeaders
        public ICollection<AdminGroupLeader> AdminGroupLeaders { get; set; }
    }
}
