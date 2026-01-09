using Domain.Entity;
using Domain.Repository;

namespace Infrastructure.Repository
{
    public class OrderRepository : EFRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
