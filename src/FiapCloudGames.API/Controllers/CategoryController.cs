using Domain.Entity;
using Domain.Input;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloudGames.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var category = _categoryRepository.GetAll();
                return Ok(category);
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
                var category = _categoryRepository.GetById(id);
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
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

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
