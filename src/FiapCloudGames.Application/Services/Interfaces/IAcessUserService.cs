using Domain.Entity;
using Domain.Repository;
using Domain.Input;

namespace FiapCloudGames.Application.Services.Interfaces
{
    public interface IAcessUserService
    {
        Task<IList<AcessUser>> GetAllUsers();

        Task<AcessUser> GetUserById(int id);

        Task<AcessUser> CreateAcessUser(AcessUserInput acessUser);

    }
}
