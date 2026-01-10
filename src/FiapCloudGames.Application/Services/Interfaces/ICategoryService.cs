using Domain.Entity;
using Domain.Input;

namespace FiapCloudGames.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IList<Category>> GetAll();

        Task<Category> GetCategoryById(int id);

        Task<Category> CreateCategory(CategoryInput category);
    }
}
