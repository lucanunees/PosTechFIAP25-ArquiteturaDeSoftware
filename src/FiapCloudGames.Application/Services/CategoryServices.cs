using Domain.Entity;
using Domain.Input;
using Domain.Repository;
using FiapCloudGames.Application.Services.Interfaces;

namespace FiapCloudGames.Application.Services
{
    public class CategoryServices : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> CreateCategory(CategoryInput category)
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
