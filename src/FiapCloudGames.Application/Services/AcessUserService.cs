using Domain.Entity;
using Domain.Input;
using Domain.Repository;
using FiapCloudGames.Application.Services.Interfaces;
using FiapCloudGames.Domain.Enum;

namespace FiapCloudGames.Application.Services
{
    public class AcessUserService : IAcessUserService
    {
        private readonly IAcessUserRepository _acessUserRepository;
        public AcessUserService(IAcessUserRepository acessUserRepository)
        {
            _acessUserRepository = acessUserRepository;
        }

        public async Task<IList<AcessUser>> GetAllUsers()
        {
            var acessUsers = _acessUserRepository.GetAll();
            return acessUsers;
        }

        public async Task<AcessUser> GetUserById(int id)
        {
            var user = _acessUserRepository.GetById(id);
            return user;
        }

        public async Task<AcessUser> CreateAcessUser(AcessUserInput acessUser)
        {
            try
            {
                var createUser = new AcessUser()
                {
                    Username = acessUser.Username,
                    Password = acessUser.Password,
                    Email = acessUser.Email,
                    Role = acessUser.Role
                };

                _acessUserRepository.Create(createUser);
                return createUser;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
