using FiapCloudGames.Application.Services.Interfaces;
using FiapCloudGames.Domain.Entity;
using FiapCloudGames.Domain.Repository;
using FiapCloudGames.Domain.Request;
using Microsoft.AspNetCore.Identity;

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

        public async Task<AcessUser> CreateAcessUser(UserRequest request)
        {
            try
            {
                //Hash senha
                var hasher = new PasswordHasher<IdentityUser>();
                string passwordHash = hasher.HashPassword(null, request.Password);

                var createUser = new AcessUser()
                {
                    Username = request.Username,
                    Password = passwordHash,
                    Email = request.Email,
                    Role = request.Role
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
