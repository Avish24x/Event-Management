using System.ComponentModel.DataAnnotations;

namespace Event_Management_Appilcation.Models
{
    public class TeamMember
    {
        [Key]
        public int TeamMemberID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public byte[] Profile_Image { get; set; }

        // Add other properties as needed

        // Navigation property
        public GroupLeader GroupLeader { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
