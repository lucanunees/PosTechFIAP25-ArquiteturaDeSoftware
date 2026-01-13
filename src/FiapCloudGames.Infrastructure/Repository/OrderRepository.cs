using FiapCloudGames.Domain.Entity;
using FiapCloudGames.Domain.Repository;
using Infrastructure.Repository;

namespace FiapCloudGames.Infrastructure.Repository
{
    public class OrderRepository : EFRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
