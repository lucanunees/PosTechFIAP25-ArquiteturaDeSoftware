using Domain.Entity;
using Domain.Input;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloudGames.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGamesRepository _gamesRepository;

        public GamesController(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var games = _gamesRepository.GetAll();
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
                var game = _gamesRepository.GetById(id);
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

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
