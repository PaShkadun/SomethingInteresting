using System.ComponentModel.DataAnnotations;

namespace NewIdentity.Models
{
    public class UserRegister
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

