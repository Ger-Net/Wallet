using Microsoft.EntityFrameworkCore;
using Wallet.Core.Abstract;
using Wallet.Core.Models;
using Wallet.Persistence.DataBases;
using Wallet.Persistence.Entities;

namespace Wallet.Persistence.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private readonly AppDbContext _dbContext;

        public OperationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Create(Operation operation)
        {
            
            var operationEntity = new OperationEntity()
            {
                Id = operation.Id,
                Name = operation.Name,
                Description = operation.Description,
                Amount = operation.Amount,
                User = MapUser(operation.User),
                UserId = operation.UserId
            };

            await _dbContext.Operations.AddAsync(operationEntity);
            await _dbContext.SaveChangesAsync();

            return operationEntity.Id;
        }

        public Task<Guid> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Operation> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Update(Guid id, string name, string description, decimal amount, OperationType type)
        {
            throw new NotImplementedException();
        }

        private UserEntity MapUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
