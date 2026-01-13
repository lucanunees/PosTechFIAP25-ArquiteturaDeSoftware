using FiapCloudGames.Domain.Entity;
using FiapCloudGames.Domain.Repository;
using Infrastructure.Repository;

namespace FiapCloudGames.Infrastructure.Repository
{
    public class CategoryRepository : EFRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
