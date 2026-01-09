using FiapCloudGames.API.Controllers;
using Domain.Repository;

using Microsoft.AspNetCore.Mvc;
using Domain.Input;
using Domain.Entity;

namespace FiapCloudGames.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcessUserController : ControllerBase
    {
        private readonly IAcessUserRepository _acessUserRepository;

        public AcessUserController(IAcessUserRepository acessUserRepository)
        {
            _acessUserRepository = acessUserRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var acessUsers = _acessUserRepository.GetAll();
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
                var acessUser = _acessUserRepository.GetId(id);
                if (acessUser == null)
                {
                    return NotFound();
                }
                return Ok(acessUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] AcessUserInput input)
        {
            try
            {
                var createUser = new AcessUser()
                {
                    Username = input.Username,
                    Password = input.Password,
                    Email = input.Email

                };

                _acessUserRepository.Create(createUser);

                return CreatedAtAction(nameof(GetById), new { id = createUser.Id }, createUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
