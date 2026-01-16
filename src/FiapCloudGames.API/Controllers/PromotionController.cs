using FiapCloudGames.Application.Services.Interfaces;
using FiapCloudGames.Domain.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloudGames.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = "Admin")]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService _service;
        private readonly ILogger<AcessUserController> _logger;

        public PromotionController(IPromotionService service, ILogger<AcessUserController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            try
            {
                var promotions = await _service.GetAllAsync();

                _logger.LogInformation("Lista de todas promoções retornada com sucesso.");

                return Ok(promotions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao consultar todas as promoções. [ {ex.Message} ]");

                return BadRequest(ex);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var promotions = await _service.GetAllAsync();
                var promotion = await _service.GetByIdAsync(id);

                if (promotion == null)
                {
                    _logger.LogInformation($"Promoção id: [ {id} ] não encontrada na base de dados.");

                    return NotFound();
                }

                _logger.LogInformation($"Consulta a promoção id: {id} - {promotion.Title} retornada com sucesso.");

                return Ok(promotion);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao consultar a promoção. [ {ex.Message} ]");

                return BadRequest(ex);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PromotionRequest request)
        {
            var promotions = await _service.GetAllAsync();
            var promocao = promotions.FirstOrDefault(p => p.Title == request.Title);

            if (promocao != null)
            {
                _logger.LogInformation($"Promoção [ {promocao.Title} ] já está cadastrada.");

                return BadRequest(new { message = "Promoção já está cadastrada!" });
            }

            try
            {
                var created = await _service.CreateAsync(request);

                _logger.LogInformation($"Promoção {request.Title} cadastrada com sucesso.");

                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, $"Erro ao tentar incluir a promoção. [ {ex.Message} ]");

                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] PromotionRequest request)
        {
            try
            {
                var updated = await _service.UpdateAsync(id, request);

                if (updated is null)
                {
                    _logger.LogInformation($"Promoção não encontrada.");

                    return NotFound();
                }

                _logger.LogInformation($"Promoção {request.Title} atualizada com sucesso.");

                return Ok(updated);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, $"Erro ao tentar alterar a promoção. [ {ex.Message} ]");

                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removed = await _service.DeleteAsync(id);

            if (!removed)
            {
                _logger.LogInformation($"Promoção não encontrada.");

                return NotFound();
            }

            _logger.LogInformation($"Promoção excluída com sucesso.");

            return NoContent();
        }
    }
}