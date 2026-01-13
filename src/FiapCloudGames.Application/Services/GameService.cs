using FiapCloudGames.Application.Services.Interfaces;
using FiapCloudGames.Domain.Entity;
using FiapCloudGames.Domain.Repository;
using FiapCloudGames.Domain.Request;

namespace FiapCloudGames.Application.Services
{
    public class GameService : IGameService
    {
        private readonly IGamesRepository _gamesRepository;
       
        public GameService(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        public async Task<Games> CreateGame(GameRequest game)
        {
            try
            {
                var createGame = new Games()
                {
                    Name = game.Name,
                    Price = game.Price,
                    Description = game.Description,
                    CategoryId = game.CategoryId,
                    ReleaseDate = game.ReleaseDate
                };

                _gamesRepository.Create(createGame);
                return createGame;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IList<Games>> GetAll()
        {
            try
            {
                return _gamesRepository.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Games> GetGameById(int id)
        {
            try
            {
                return _gamesRepository.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}