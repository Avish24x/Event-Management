using Org.BouncyCastle.Tls.Crypto.Impl.BC;

namespace Event_Management_Appilcation.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public byte[] Profile_Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
