using Wallet.Core.Models;

namespace Wallet.Core.Abstract
{
    public interface IUserRepository
    {
        Task<Guid> Create(User user);
        Task<Guid> Delete(Guid id);
        Task<User> Get(Guid id);
        Task<Guid> Update(Guid id, string name, string email, string password);
    }
}