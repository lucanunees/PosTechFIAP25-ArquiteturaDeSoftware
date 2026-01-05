using Core.Entity;
using Core.Input;
using Core.Repository;
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
