using Wallet.Core.Abstract;
using Wallet.Core.Models;

namespace Wallet.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
        }
        
    }
}
