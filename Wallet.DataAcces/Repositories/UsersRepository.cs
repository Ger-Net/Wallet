using Microsoft.EntityFrameworkCore;
using Wallet.Core.Models;
using Wallet.Persistence.DataBases;
using Wallet.Persistence.Entities;

namespace Wallet.Core.Abstract
{
    public class UsersRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UsersRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddOperationAsync(Operation operation)
        {
            throw new NotImplementedException();
        }

        public async Task AddUserAsync(User user)
        {
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteOperationAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Operation> GetOperationByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Operation>> GetOperationsByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserWithOperationsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOperationAsync(Operation operation)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
