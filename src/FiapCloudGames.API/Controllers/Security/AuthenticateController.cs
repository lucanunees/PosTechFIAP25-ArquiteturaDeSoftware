using FiapCloudGames.Application.Services.Interfaces;
using FiapCloudGames.Domain.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloudGames.API.Controllers.Security
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticateController(IAcessUserService userService,
    ITokenService tokenService) : ControllerBase
    {

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AcessUserRequest acessUser)
        {
            var users = await userService.GetAllUsers();
            var user = users.FirstOrDefault(u => u.Username == acessUser.Username && u.Email == acessUser.Email);

            var hasher = new PasswordHasher<object>();
            var resultado = hasher.VerifyHashedPassword(null, user.Password, acessUser.Password);


            if (resultado == PasswordVerificationResult.Failed)
                return Unauthorized(new { message = "Usuário ou senha inválidos" });

            var token = tokenService.GenereteToken(user);

            return Ok(new
            {
                authenticated = true,
                token,
                expiration = DateTime.UtcNow.AddMinutes(60)
            });
        }
    }
}
