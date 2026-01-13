using FiapCloudGames.Domain.Entity;
using FiapCloudGames.Domain.Request;

namespace FiapCloudGames.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<IList<User>> GetAllUsers();

        Task<User> GetUserById(int id);

        Task<User> CreateAcessUser(UserRequest acessUser);

    }
}
