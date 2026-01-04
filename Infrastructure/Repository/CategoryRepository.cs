using Core.Entity;
using Core.Repository;

namespace Infrastructure.Repository
{
    public class CategoryRepository : EFRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
