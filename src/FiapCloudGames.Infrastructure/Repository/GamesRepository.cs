using FiapCloudGames.Domain.Entity;
using FiapCloudGames.Domain.Repository;
using Infrastructure.Repository;

namespace FiapCloudGames.Infrastructure.Repository
{
    public class GamesRepository : EFRepository<Games>, IGamesRepository
    {
        public GamesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
