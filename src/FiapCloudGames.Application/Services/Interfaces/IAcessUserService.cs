using FiapCloudGames.Domain.Entity;
using FiapCloudGames.Domain.Request;

namespace FiapCloudGames.Application.Services.Interfaces
{
    public interface IAcessUserService
    {
        Task<IList<AcessUser>> GetAllUsers();

        Task<AcessUser> GetUserById(int id);

        Task<AcessUser> CreateAcessUser(UserRequest acessUser);

    }
}
