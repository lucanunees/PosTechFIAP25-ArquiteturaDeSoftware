using Domain.Entity;
using Domain.Input;
using FiapCloudGames.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloudGames.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<IActionResult> Post([FromBody] AcessUserInput input)
        {
            var users = await _acessUserService.GetAllUsers();
            var user = users.FirstOrDefault(u => u.Username == input.Username && u.Email == input.Email);

            if (user != null)
                return BadRequest(new { message = "Usuário já está cadastrado!" });

            try
            {
                var createdUser = await _acessUserService.CreateAcessUser(input);
                return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
