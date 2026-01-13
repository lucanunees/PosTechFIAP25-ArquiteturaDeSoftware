using System.ComponentModel.DataAnnotations;

namespace FiapCloudGames.Domain.Request
{
    public class CategoryRequest
    {
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
