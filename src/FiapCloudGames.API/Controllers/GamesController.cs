using FiapCloudGames.Application.Services.Interfaces;
using FiapCloudGames.Domain.Request;
using FiapCloudGames.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloudGames.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gamesService;
        private readonly LoggerBase<GamesController> _logger;

        public GamesController(IGameService gamesService)
        {
            _gamesService = gamesService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var games = _gamesService.GetAll();
                return Ok(games);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar todos os jogos. [ {ex.Message} ]");

                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                var game = _gamesService.GetGameById(id);
                if (game == null)
                {

                    _logger.LogInformation($"Jogo não encontrado. Id: [ {id} ]");

                    return NotFound();
                }

                _logger.LogInformation($"Jogo encontrado. Nome: [ {game.Result.Name} ]");

                return Ok(game);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar jogo. [ {ex.Message} ]");

                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] GameRequest request)
        {
            try
            {
                var game = new GameRequest()
                {
                    Name = request.Name,
                    Price = request.Price,
                    Description = request.Description,
                    CategoryId = request.CategoryId,
                    ReleaseDate = request.ReleaseDate
                };

                _gamesService.CreateGame(game);

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
