namespace FiapCloudGames.Domain.Entity
{
    public class Category : EntityBase
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
