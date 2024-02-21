namespace Event.Management.Data.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public string? RoleName { get; set; }
        public string? RoleDescription { get; set;}
        public ICollection<User>? users { get; set; }
    }
}
