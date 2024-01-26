using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Management_Appilcation.Models
{
    public class GroupTable
    {
        public int GroupID { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Objectives { get; set; }
        [ForeignKey("AdminID")]
        public Admin AdminID { get; set; }
        [ForeignKey("GroupLeaderID")]
        public GroupLeader GroupLeaderID { get; set; }
    }
}
