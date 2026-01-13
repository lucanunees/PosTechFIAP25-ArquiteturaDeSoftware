using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloudGames.API.Controllers.Security
{
    public class SecureController : ControllerBase
    {
        [HttpGet("admin")]
        [Authorize(Policy = "Admin")]
        public IActionResult AdminOnly()
        {
            return Ok("Este endpoint é acessível apenas por admin.");
        }

        [HttpGet("user")]
        [Authorize]
        public IActionResult AnyUser()
        {
            return Ok("Este endpoint é acessível por qualquer usuário.");
        }
    }
}
