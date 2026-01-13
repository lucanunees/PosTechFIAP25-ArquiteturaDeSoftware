using FiapCloudGames.Application.Services.Interfaces;
using FiapCloudGames.Domain.Entity;
using FiapCloudGames.Domain.Repository;
using FiapCloudGames.Domain.Request;
using Microsoft.AspNetCore.Identity;

namespace FiapCloudGames.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IList<User>> GetAllUsers()
        {
            var acessUsers = _userRepository.GetAll();
            return acessUsers;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = _userRepository.GetById(id);
            return user;
        }

        public async Task<User> CreateAcessUser(UserRequest acessUser)
        {
            try
            {
                //Hash senha
                var hasher = new PasswordHasher<IdentityUser>();
                string passwordHash = hasher.HashPassword(null, acessUser.Password);

                var createUser = new User()
                {
                    Username = acessUser.Username,
                    Password = passwordHash,
                    Email = acessUser.Email,
                    Role = acessUser.Role
                };

                _userRepository.Create(createUser);
                return createUser;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
