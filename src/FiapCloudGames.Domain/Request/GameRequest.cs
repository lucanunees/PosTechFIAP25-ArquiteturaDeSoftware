using System;
using System.ComponentModel.DataAnnotations;

namespace FiapCloudGames.Domain.Request
{
    public class GameRequest
    {
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "O Preço é obrigatório.")]
        public decimal Price { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "A Categoria é obrigatória.")]
        public int CategoryId { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
