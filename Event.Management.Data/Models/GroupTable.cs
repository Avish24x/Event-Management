using Event.Management.Data.Models;
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
        public int? EventID { get; set; } = null;
        public SDEvent? Event { get; set; }
        public ICollection<SDEvent>? events { get; set; }
        public ICollection<User>? users { get; set; }
       

    }
}
