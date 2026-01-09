using Domain.Entity;
using Domain.Repository;

namespace Infrastructure.Repository
{
    public class GamesRepository : EFRepository<Games>, IGamesRepository
    {
        public GamesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
