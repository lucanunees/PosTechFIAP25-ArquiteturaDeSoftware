using FiapCloudGames.Domain.Entity;
using FiapCloudGames.Domain.Request;

namespace FiapCloudGames.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IList<Category>> GetAll();

        Task<Category> GetCategoryById(int id);

        Task<Category> CreateCategory(CategoryRequest category);
    }
}
