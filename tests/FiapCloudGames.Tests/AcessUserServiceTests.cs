using FiapCloudGames.Application.Services;
using FiapCloudGames.Domain.Entity;
using FiapCloudGames.Domain.Repository;
using FiapCloudGames.Domain.Request;
using FluentAssertions;
using Moq;

public class AcessUserServiceTests
{
    private readonly Mock<IAcessUserRepository> _repositoryMock;
    private readonly AcessUserService _service;

    public AcessUserServiceTests()
    {
        _repositoryMock = new Mock<IAcessUserRepository>();
        _service = new AcessUserService(_repositoryMock.Object);
    }

    [Fact]
    public async Task GetAllUsers_DeveRetornarListaUsuario_QuandoUsuarioExistir()
    {
        // Arrange
        var mockUsers = new List<AcessUser>
        {
            new AcessUser {Username = "user1", Password = "senha132", Email = "user1@email.com" },
            new AcessUser { Username = "user2", Password = "senha132", Email = "user2@email.com" }
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
    public async Task GetUserById_DeveRetornarListaUsuario_QuandoUsuarioExistir()
    {
        // Arrange
        var userId = 1;
        var mockUser = new AcessUser { Username = "testuser", Password = "senhauser", Email = "user@email.com" };
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
        var input = new AcessUserRequest
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
        _repositoryMock.Verify(r => r.Create(It.Is<AcessUser>(u =>
            u.Username == input.Username &&
            u.Email == input.Email)), Times.Once);
    }

    [Fact]
    public async Task CreateAcessUser_DeveRetornarExcecao_QuandoObterErroCriarUsuario()
    {
        // Arrange
        var input = new AcessUserRequest { Username = "usererror", Password = "123456", Email = "emailemail@" };
        _repositoryMock.Setup(r => r.Create(It.IsAny<AcessUser>()))
                       .Throws(new Exception("Database error"));

        // Act
        Func<Task> act = async () => await _service.CreateAcessUser(input);

        // Assert
        await act.Should().ThrowAsync<Exception>();
    }
}