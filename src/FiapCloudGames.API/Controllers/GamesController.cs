using FiapCloudGames.Application.Services.Interfaces;
using FiapCloudGames.Domain.Request;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloudGames.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gamesService;
        private readonly ILogger<AcessUserController> _logger;

        public GamesController(IGameService gamesService, ILogger<AcessUserController> logger)
        {
            _gamesService = gamesService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var games = await _gamesService.GetAll();

                _logger.LogInformation("Lista de todos jodos retornada com sucesso.");

                return Ok(games);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar todos os jogos. [ {ex.Message} ]");

                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var game = await _gamesService.GetGameById(id);

                if (game == null)
                {
                    _logger.LogInformation($"Jogo id: [ {id} ] não encontrado na base de dados.");

                    return NotFound();
                }

                _logger.LogInformation($"Jogo encontrado. Nome: [ {game.Name} ]");

                return Ok(game);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar jogo. [ {ex.Message} ]");

                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GameRequest request)
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

                await _gamesService.CreateGame(game);

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
