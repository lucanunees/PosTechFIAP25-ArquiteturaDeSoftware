using FiapCloudGames.Application.Services.Interfaces;
using FiapCloudGames.Domain.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloudGames.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcessUserController : ControllerBase
    {
        private readonly IAcessUserService _acessUserService;
        
        public AcessUserController(IAcessUserService acessUserService)
        {
            _acessUserService = acessUserService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var acessUsers = _acessUserService.GetAllUsers();
                return Ok(acessUsers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                var user = _acessUserService.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] AcessUserRequest request)
        {
            var users = await _acessUserService.GetAllUsers();
            var user = users.FirstOrDefault(u => u.Username == request.Username && u.Email == request.Email);

            if (user != null)
                return BadRequest(new { message = "Usuário já está cadastrado!" });

            try
            {
                var createdUser = await _acessUserService.CreateAcessUser(request);
                return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
