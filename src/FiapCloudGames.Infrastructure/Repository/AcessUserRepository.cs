using Domain.Entity;
using Domain.Repository;

namespace Infrastructure.Repository
{
    public class AcessUserRepository : EFRepository<AcessUser>, IAcessUserRepository
    {
        public AcessUserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
