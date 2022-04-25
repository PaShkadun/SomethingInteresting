namespace NewIdentity.Models
{
    public class UserResponse
    {
        public string UserId { get; }

        public string Name { get; }

        public string Email { get; }

        public string Password { get; }

        public UserResponse(AuthUser user, string password)
        {
            UserId = user.Id;
            Name = user.Name;
            Email = user.Email;
            Password = password;
        }
    }
}
