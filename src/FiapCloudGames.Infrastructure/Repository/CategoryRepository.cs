using Domain.Entity;
using Domain.Repository;

namespace Infrastructure.Repository
{
    public class CategoryRepository : EFRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
