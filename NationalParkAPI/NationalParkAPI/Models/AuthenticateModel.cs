using System.ComponentModel.DataAnnotations;

namespace NationalParkAPI.Models
{
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
