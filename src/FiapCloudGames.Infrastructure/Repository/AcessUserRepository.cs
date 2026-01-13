using FiapCloudGames.Domain.Entity;
using FiapCloudGames.Domain.Repository;
using FiapCloudGames.Infrastructure.Repository;

namespace Infrastructure.Repository
{
    public class AcessUserRepository : EFRepository<AcessUser>, IAcessUserRepository
    {
        public AcessUserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
