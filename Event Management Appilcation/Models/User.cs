using Org.BouncyCastle.Tls.Crypto.Impl.BC;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Event_Management_Appilcation.Models
{
    [Table("Users")]
    public class User : IdentityUser<int>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public byte[] Profile_Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public ICollection<UserEvent> UserEvents { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
