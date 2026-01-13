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
                    return NotFound();
                }
                return Ok(game);
            }
            catch (Exception ex)
            {
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

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
