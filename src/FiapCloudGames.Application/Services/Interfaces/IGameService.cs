using Domain.Entity;
using Domain.Input;

namespace FiapCloudGames.Application.Services.Interfaces
{
    public interface IGameService
    {
        Task<IList<Games>> GetAll();

        Task<Games> GetGameById(int id);

        Task<Games> CreateGame(GameInput game);
    }
}
