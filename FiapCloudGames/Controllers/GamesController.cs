using Core.Entity;
using Core.Input;
using Core.Repository;
using Infrastructure.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloudGames.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly LoggerBase<GamesController> _logger;

        public GamesController(IGamesRepository gamesRepository, LoggerBase<GamesController> logger)
        {
            _gamesRepository = gamesRepository;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] GameInput input)
        {
            try
            {
                var game = new Games()
                {
                    Name = input.Name,
                    Price = input.Price,
                    Description = input.Description,
                    CategoryId = input.CategoryId,
                    ReleaseDate = input.ReleaseDate
                };

                _gamesRepository.Create(game);

                _logger.LogInformation($"Novo jogo incluído com sucesso.[ {game.Name} ]");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na inclusão do novo jogo. [ {ex.Message} ]");

                return BadRequest(ex);
            }
        }
    }
}
