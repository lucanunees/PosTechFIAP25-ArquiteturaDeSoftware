using FiapCloudGames.Domain.Enum;

namespace FiapCloudGames.Domain.Entity
{
    public class User : EntityBase
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public UserRoleEnum Role { get; set; }
    }
}
