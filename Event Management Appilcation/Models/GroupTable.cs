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
        public Event? Event { get; set; }
        public ICollection<Event>? events { get; set; }
        public ICollection<User>? users { get; set; }
       

    }
}
