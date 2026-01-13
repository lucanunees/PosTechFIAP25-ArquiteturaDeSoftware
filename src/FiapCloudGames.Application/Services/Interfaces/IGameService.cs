using FiapCloudGames.Domain.Entity;
using FiapCloudGames.Domain.Request;

namespace FiapCloudGames.Application.Services.Interfaces
{
    public interface IGameService
    {
        Task<IList<Games>> GetAll();

        Task<Games> GetGameById(int id);

        Task<Games> CreateGame(GameRequest game);
    }
}
