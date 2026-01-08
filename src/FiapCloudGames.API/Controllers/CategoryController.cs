using Domain.Entity;
using Domain.Input;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloudGames.Controllers
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
