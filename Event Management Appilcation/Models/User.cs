using Org.BouncyCastle.Tls.Crypto.Impl.BC;
using Microsoft.AspNetCore.Identity;

namespace Event_Management_Appilcation.Models
{
    public class User : IdentityUser<int>
    {
        public override int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public byte[] Profile_Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<UserEvent> UserEvents { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
