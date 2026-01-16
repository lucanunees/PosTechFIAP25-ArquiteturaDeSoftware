using FiapCloudGames.Domain.Enum;
using FiapCloudGames.Domain.Request;
using System.ComponentModel.DataAnnotations;


namespace FiapCloudGames.Tests
{

    public class UserRequestTests
    {
        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }

        [Fact]
        public void UserRequest_ValidarDados_DeveNaoTerValidacoesComErro()
        {
            // Arrange
            var request = new AcessUserRequest
            {
                Username = "usuario123",
                Email = "teste@email.com",
                Password = "Senha@123",
                Role = UserRoleEnum.Admin
            };

            // Act
            var errors = ValidateModel(request);

            // Assert
            Assert.Empty(errors);
        }

        [Theory]
        [InlineData(null, "O username é obrigatório.")]
        [InlineData("ab", "O nome deve ter entre 3 e 100 caracteres.")]
        public void UserRequest_UsernameInvalido_DeveRetornarMensagemDeErro(string username, string expectedError)
        {
            // Arrange
            var request = new AcessUserRequest { Username = username, Email = "valid@mail.com", Password = "Valid@123" };

            // Act
            var errors = ValidateModel(request);

            // Assert
            Assert.Contains(errors, v => v.ErrorMessage == expectedError);
        }

        [Theory]
        [InlineData(null, "O e-mail é obrigatório.")]
        [InlineData("emailinvalido", "Formato de e-mail inválido.")]
        public void UserRequest_EmailInvalido_DeveRetornarMensagemDeErro(string email, string expectedError)
        {
            // Arrange
            var request = new AcessUserRequest { Username = "User", Email = email, Password = "Senha@123" };

            // Act
            var errors = ValidateModel(request);

            // Assert
            Assert.Contains(errors, v => v.ErrorMessage == expectedError);
        }

        [Theory]
        [InlineData(null, "A senha é obrigatória.")]
        [InlineData("1234567", "A senha deve ter no mínimo 8 caracteres.")]
        [InlineData("soletra", "A senha deve conter letras, números e pelo menos um caractere especial.")]
        [InlineData("12345678", "A senha deve conter letras, números e pelo menos um caractere especial.")]
        [InlineData("Senha123", "A senha deve conter letras, números e pelo menos um caractere especial.")]
        public void UserRequest_InvalidPassword_ShouldReturnErrorMessage(string password, string expectedError)
        {
            // Arrange
            var request = new AcessUserRequest { Username = "User", Email = "user@email.com", Password = password };

            // Act
            var errors = ValidateModel(request);

            // Assert
            Assert.Contains(errors, v => v.ErrorMessage == expectedError);
        }
    }
}
