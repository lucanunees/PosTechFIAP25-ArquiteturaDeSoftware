using FiapCloudGames.Application.Services.Interfaces;
using FiapCloudGames.Domain.Request;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloudGames.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<AcessUserController> _logger;

        public CategoryController(ICategoryService categoryService, ILogger<AcessUserController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var category = await _categoryService.GetAll();

                _logger.LogInformation("Lista de todas categorias retornada com sucesso.");

                return Ok(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao consultar todos as categorias. [ {ex.Message} ]");

                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var category = await _categoryService.GetCategoryById(id);

                if (category == null)
                {
                    _logger.LogInformation($"Categoria id: [ {id} ] não encontrada na base de dados.");

                    return NotFound();
                }
                
                _logger.LogInformation($"Consulta a categoria id: {id} - {category.Name} retornada com sucesso.");

                return Ok(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao consultar a categoria. [ {ex.Message} ]");

                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryRequest request)
        {

            var categorias = await _categoryService.GetAll();
            var categoria = categorias.FirstOrDefault(u => u.Name == request.Name);

            if (categoria != null)
            {
                _logger.LogInformation($"Categoria [ {categoria.Name} ] já está cadastrada.");

                return BadRequest(new { message = "Categoria já está cadastrada!" });
            }

            try
            {
                var category = new CategoryRequest()
                {
                    Name = request.Name,
                    Description = request.Description
                };

                await _categoryService.CreateCategory(category);

                _logger.LogInformation($"Categoria {request.Name} cadastrada com sucesso.");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao tentar incluir a categoria. [ {ex.Message} ]");

                return BadRequest(ex);
            }
        }
    }
}
