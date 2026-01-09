using Domain.Entity;
using Domain.Repository;

namespace Infrastructure.Repository
{
    public class CustomerRepository : EFRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
