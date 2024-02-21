using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Event_Management_Appilcation.Models.Authentication.Login
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]

        public string? Username { get; set; }


        [Required(ErrorMessage = "Password is required")]

        public string? Password { get; set; }
    }
}