using FiapCloudGames.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Domain.Input
{
    public class AcessUserInput
    {
        [Required(ErrorMessage = "O username é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "A senha deve conter letras, números e pelo menos um caractere especial.")]
        public string Password { get; set; }
        public UserRoleEnum Role { get; set; }
    }
}
