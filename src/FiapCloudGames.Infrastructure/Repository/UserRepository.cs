using FiapCloudGames.Domain.Entity;
using FiapCloudGames.Domain.Repository;
using Infrastructure.Repository;

namespace FiapCloudGames.Infrastructure.Repository
{
    public class UserRepository : EFRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
