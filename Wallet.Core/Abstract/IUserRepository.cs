using Wallet.Core.Models;

namespace Wallet.Core.Abstract
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserWithOperationsAsync(int id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);

        Task AddOperationAsync(Operation operation);
        Task<IEnumerable<Operation>> GetOperationsByUserIdAsync(int userId);
        Task<Operation> GetOperationByIdAsync(int id);
        Task UpdateOperationAsync(Operation operation);
        Task DeleteOperationAsync(int id);
    }
}