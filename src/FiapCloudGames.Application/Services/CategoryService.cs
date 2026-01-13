using FiapCloudGames.Application.Services.Interfaces;
using FiapCloudGames.Domain.Entity;
using FiapCloudGames.Domain.Repository;
using FiapCloudGames.Domain.Request;

namespace FiapCloudGames.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> CreateCategory(CategoryRequest category)
        {
            try
            {
                var createCategory = new Category()
                {
                    Name = category.Name,
                    Description = category.Description
                };

                _categoryRepository.Create(createCategory);
                return createCategory;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IList<Category>> GetAll()
        {
            try
            {
                return _categoryRepository.GetAll();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Category> GetCategoryById(int id)
        {
            try
            {
                return _categoryRepository.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
