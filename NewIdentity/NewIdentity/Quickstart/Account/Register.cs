using NewIdentity.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using System;

namespace AuthServer.Web.Controllers
{
    [Route("register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<AuthUser> userManager;

        public RegisterController(UserManager<AuthUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<UserResponse> Register([FromBody] UserRegister registerUser)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            var user = new AuthUser
            {
                Name = registerUser.Name,
                UserName = registerUser.Email,
                Email = registerUser.Email
            };

            var isExist = await userManager.FindByEmailAsync(registerUser.Email);

            if (isExist is not null)
            {
                var authUser = new AuthUser();
                authUser.Email = "error";

                return new UserResponse(authUser, "");
            }

            var result = await userManager.CreateAsync(user, registerUser.Password);

            if (!result.Succeeded)
            {
                var authUser = new AuthUser();

                return new UserResponse(authUser, "error");
            }

            await userManager.AddClaimAsync(user, new Claim("userName", user.UserName));
            await userManager.AddClaimAsync(user, new Claim("name", user.Name));
            await userManager.AddClaimAsync(user, new Claim("userId", user.Id));
            await userManager.AddClaimAsync(user, new Claim("role", Roles.User));

            var code = await userManager.GenerateEmailConfirmationTokenAsync(user);

            return new UserResponse(user, "");
        }
    }
}
