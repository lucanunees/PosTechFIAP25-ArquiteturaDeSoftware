using Moq;
using FluentAssertions;
using FiapCloudGames.Application.Services;
using FiapCloudGames.Domain.Entity;
using FiapCloudGames.Domain.Repository;
using FiapCloudGames.Domain.Request;

public class AcessUserServiceTests
{
    private readonly Mock<IUserRepository> _repositoryMock;
    private readonly UserService _service;

    public AcessUserServiceTests()
    {
        _repositoryMock = new Mock<IUserRepository>();
        _service = new UserService(_repositoryMock.Object);
    }

    [Fact]
    public async Task GetAllUsers_DeveRetornarListaUsuario_QuandoUsuarioExistir()
    {
        // Arrange
        var mockUsers = new List<User>
        {
            new User {Username = "user1", Password = "senha132", Email = "user1@email.com" },
            new User { Username = "user2", Password = "senha132", Email = "user2@email.com" }
        };
        _repositoryMock.Setup(r => r.GetAll()).Returns(mockUsers);

        // Act
        var result = await _service.GetAllUsers();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result[0].Username.Should().Be("user1");
        _repositoryMock.Verify(r => r.GetAll(), Times.Once);
    }

    [Fact]
    public async Task GetUserById_DeveRetornarUsuario_QuandoIdUsuarioExistir()
    {
        // Arrange
        var userId = 1;
        var mockUser = new User { Username = "testuser", Password = "senhauser", Email = "user@email.com" };
        _repositoryMock.Setup(r => r.GetById(userId)).Returns(mockUser);

        // Act
        var result = await _service.GetUserById(userId);

        // Assert
        result.Should().NotBeNull();
        result.Username.Should().Be("testuser");
        _repositoryMock.Verify(r => r.GetById(userId), Times.Once);
    }

    [Fact]
    public async Task CreateAcessUser_DeveRetornarUsuarioCriado_QuandoInputValido()
    {
        // Arrange
        var input = new UserRequest
        {
            Username = "newuser",
            Password = "senha123",
            Email = "test@email.com"
        };

        // Act
        var result = await _service.CreateAcessUser(input);

        // Assert
        result.Should().NotBeNull();
        result.Username.Should().Be(input.Username);
        result.Email.Should().Be(input.Email);

        // Verifica se o repositório foi chamado com as propriedades corretas
        _repositoryMock.Verify(r => r.Create(It.Is<User>(u =>
            u.Username == input.Username &&
            u.Email == input.Email)), Times.Once);
    }

    [Fact]
    public async Task CreateAcessUser_DeveRetornarExcecao_QuandoObterErroCriarUsuario()
    {
        // Arrange
        var input = new UserRequest { Username = "usererror", Password = "123456", Email = "emailemail@" };
        _repositoryMock.Setup(r => r.Create(It.IsAny<User>()))
                       .Throws(new Exception("Database error"));

        // Act
        Func<Task> act = async () => await _service.CreateAcessUser(input);

        // Assert
        await act.Should().ThrowAsync<Exception>();
    }
}