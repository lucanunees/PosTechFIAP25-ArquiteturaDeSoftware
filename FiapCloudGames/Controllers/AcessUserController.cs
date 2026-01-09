using Core.Entity;
using Core.Input;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace FiapCloudGames.Controllers
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
            //if (!ValidarDados(input, out var erro))
            //{
            //    return BadRequest(new { message = erro });
            //}
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


        public bool ValidarDados(AcessUserInput input, out string mensagem)
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            var senhaRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");

            if (!emailRegex.IsMatch(input.Email))
            {
                mensagem = "Formato de e-mail inválido.";
                return false;
            }

            if (!senhaRegex.IsMatch(input.Password))
            {
                mensagem = "A senha deve ter no mínimo 8 caracteres, incluindo letras, números e caracteres especiais.";
                return false;
            }

            mensagem = "";
            return true;
        }
    }
}
