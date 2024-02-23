using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Event_Management_Appilcation.Models;

namespace Event.Management.Data.Models
{
    
    public class User 
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string? Password { get; set; }

        public string Email { get; set; }

        public string? ProfileImage { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public int? RoleID { get; set; } = null;

        public Role? Role { get; set; }

        public int? GroupID { get; set; } = null;

        public GroupTable? GroupTable { get; set; }

        public ICollection<UserEvent>? UserEvents { get; set; }

        public ICollection<Role>? Roles { get; set; }

        public ICollection<Feedback>? Feedbacks { get; set; }

    }
}
