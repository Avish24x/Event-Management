using Org.BouncyCastle.Asn1.X509;

namespace Event_Management_Appilcation.Models
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string UserName { get;  set; }
        public string Password { get; set; }
        public byte[] Profile_image{ get; set; }
        public char email { get; set; }

    }
}
