using Wallet.Core.Abstract;
using Wallet.Core.Models;

namespace Wallet.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Guid> Create(User user)
        {
            return await _userRepository.Create(user);
        }

        public async Task<Guid> Delete(Guid id)
        {
            return await _userRepository.Delete(id);
        }

        public async Task<User> Get(Guid id)
        {
            return await _userRepository.Get(id);
        }

        public async Task<Guid> Update(Guid id, string name, string email, string password)
        {
            return await _userRepository.Update(id,name,email,password);
        }
    }
}
