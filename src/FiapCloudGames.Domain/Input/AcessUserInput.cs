using FiapCloudGames.Domain.Enum;

namespace Domain.Input
{
    public class AcessUserInput
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public UserRoleEnum Role { get; set; }
    }
}
