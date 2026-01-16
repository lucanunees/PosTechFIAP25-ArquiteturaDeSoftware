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
        private readonly ILogger<AcessUserController> _logger;
        public AcessUserController(IAcessUserService acessUserService, ILogger<AcessUserController> logger)
        { 
            _acessUserService = acessUserService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var acessUsers = await _acessUserService.GetAllUsers();

                _logger.LogInformation("Lista de todos usuários retornada com sucesso.");

                return Ok(acessUsers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao consultar todos os usuários. [ {ex.Message} ]");

                return BadRequest(ex);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var user = await _acessUserService.GetUserById(id);

                if (user == null)
                {
                    _logger.LogInformation($"Usuário id: [ {id} ] não encontrado na base de dados.");

                    return NotFound();
                }
                
                _logger.LogInformation($"Consulta ao usuário id: {id} - {user.Username} retornada com sucesso.");

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao consultar o usuário. [ {ex.Message} ]");

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
            {
                _logger.LogInformation($"Usuário [ {user.Username} ] já está cadastrado.");

                return BadRequest(new { message = "Usuário já está cadastrado!" });
            }             

            try
            {
                var createdUser = await _acessUserService.CreateAcessUser(request);

                _logger.LogInformation($"Usuário {request.Username} cadastrado com sucesso.");

                return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao tentar incluir o usuário. [ {ex.Message} ]");

                return BadRequest(ex);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removed = await _acessUserService.DeleteAsync(id);

            if (!removed)
            {
                _logger.LogInformation($"Usuário não encontrado.");

                return NotFound();
            }

            _logger.LogInformation($"Usuário excluído com sucesso.");

            return NoContent();
        }
    }
}
