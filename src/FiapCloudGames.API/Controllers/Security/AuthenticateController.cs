using Domain.Input;
using FiapCloudGames.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloudGames.Controllers.Security
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController(IAcessUserService userService,
    ITokenService tokenService) : ControllerBase
    {

        [HttpPost("login")]
        public async Task<IActionResult> Login(AcessUserInput acessUser)
        {
            var users = await userService.GetAllUsers();
            var user = users.FirstOrDefault(u => u.Username == acessUser.Username && u.Password == acessUser.Password);

            if (user == null)
                return Unauthorized(new { message = "Usuário ou senha inválidos" });

            var role = user.Username == "admin" ? "Admin" : "User";

            var token = tokenService.GenereteToken(user, role);

            return Ok(new
            {
                authenticated = true,
                token,
                expiration = DateTime.UtcNow.AddMinutes(60)
            });
        }
    }
}
