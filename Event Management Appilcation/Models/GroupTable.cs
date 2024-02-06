using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Management_Appilcation.Models
{
    public class GroupTable
    {
        [Key]
        public int GroupID { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Objectives { get; set; }
        
        public int AdminID { get; set; }
        public Admin Admin { get; set; }
       

        public int GroupLeaderID { get; set; }
        public GroupLeader GroupLeader { get; set; }
    }
}
