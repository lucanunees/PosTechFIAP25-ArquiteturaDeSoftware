namespace Core.Entity
{
    public class AcessUser : EntityBase
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }

    }
}
