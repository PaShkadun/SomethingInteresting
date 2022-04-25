using Microsoft.AspNetCore.Identity;

namespace NewIdentity.Models
{
    public class AuthUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
