using FiapCloudGames.Domain.Entity;

namespace FiapCloudGames.Application.Services.Interfaces
{
    public interface ITokenService
    {
        string GenereteToken(User user);
    }
}
