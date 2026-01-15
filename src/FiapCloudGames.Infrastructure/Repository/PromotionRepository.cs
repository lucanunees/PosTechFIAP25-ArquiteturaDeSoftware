using FiapCloudGames.Domain.Entity;
using FiapCloudGames.Domain.Repository;
using Infrastructure.Repository;

namespace FiapCloudGames.Infrastructure.Repository

{
    public class PromotionRepository : EFRepository<Promotion>, IPromotionRepository
    {
        public PromotionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}