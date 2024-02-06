using Microsoft.EntityFrameworkCore;

namespace Event_Management_Appilcation.Models
{
    public class AdminGroupLeader
    {
        public int AdminID { get; set; }
        public Admin Admin { get; set; }

        public int GroupLeaderID { get; set; }
        public GroupLeader GroupLeader { get; set; }
    }
}
