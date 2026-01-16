using Moq;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using FiapCloudGames.Application.Services;
using FiapCloudGames.Domain.Entity;
using FiapCloudGames.Domain.Repository;
using FiapCloudGames.Domain.Request;

namespace FiapCloudGames.Tests
{
    public class CategoryServiceTests
    {
        private readonly Mock<ICategoryRepository> _repositoryMock;
        private readonly CategoryService _service;

        public CategoryServiceTests()
        {
            // Arrange: Inicializa o mock e a service antes de cada teste
            _repositoryMock = new Mock<ICategoryRepository>();
            _service = new CategoryService(_repositoryMock.Object);
        }

        [Fact]
        public async Task CreateCategory_DeveRetornarCategoriaCriada_QuandoSucesso()
        {
            // Arrange
            var request = new CategoryRequest { Name = "Aventura", Description = "Jogos de Aventura" };

            // Act
            var result = await _service.CreateCategory(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(request.Name, result.Name);
            Assert.Equal(request.Description, result.Description);

            _repositoryMock.Verify(r => r.Create(It.IsAny<Category>()), Times.Once);
        }

        [Fact]
        public async Task GetAll_DeveRetornarListaDeCategorias_QuandoChamadada()
        {
            // Arrange
            var categories = new List<Category>
            {
            new Category { Name = "Aventura", Description = "Jogos de Aventura" },
            new Category { Name = "Ação", Description = "Jogos de Ação."  }
            };
            _repositoryMock.Setup(r => r.GetAll()).Returns(categories);

            // Act
            var result = await _service.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Aventura", result[0].Name);
        }
                

        [Fact]
        public async Task CreateCategory_DeveGerarExceção_QuandoRepositorioFalhar()
        {
            // Arrange
            var request = new CategoryRequest { Description = "Jogos de Aventura" };
            _repositoryMock.Setup(r => r.Create(It.IsAny<Category>())).Throws(new System.Exception("Erro de Banco"));

            // Act & Assert
            await Assert.ThrowsAsync<System.Exception>(() => _service.CreateCategory(request));
        }
    }
}
