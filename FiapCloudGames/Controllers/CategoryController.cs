using Core.Entity;
using Core.Input;
using Core.Repository;
using Infrastructure.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloudGames.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly LoggerBase<GamesController> _logger;

        public CategoryController(ICategoryRepository categoryRepository, LoggerBase<GamesController> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CategoryInput input)
        {
            try
            {
                var category = new Category()
                {
                    Name = input.Name,
                    Description = input.Description
                };

                _categoryRepository.Create(category);

                _logger.LogInformation($"Nova Categoria incluída com sucesso.[ {category.Name} ]");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na inclusão da nova Categoria. [ {ex.Message} ]");

                return BadRequest(ex);
            }
        }
    }
}
