using Org.BouncyCastle.Tls.Crypto.Impl.BC;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Event_Management_Appilcation.Models
{
    
    public class User 
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? Profile_Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int? RoleID { get; set; }
        public Role? role { get; set; }
        public int? GroupID { get; set; }
        public GroupTable? groupTable { get; set; }
        public ICollection<UserEvent>? UserEvents { get; set; }
        public ICollection<Role>? roles { get; set; }
        public ICollection<Feedback>? Feedbacks { get; set; }
    }
}
