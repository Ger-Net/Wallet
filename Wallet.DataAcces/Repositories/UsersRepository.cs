using Microsoft.EntityFrameworkCore;
using Wallet.Core.Models;
using Wallet.Core.DataBases;
using Wallet.Core.Entities;

namespace Wallet.Core.Abstract
{
    public class UsersRepository : IUserRepository
    {
        private readonly UserDbContext _dbContext;
        public UsersRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> Get(Guid id)
        {
            var userEntity = await _dbContext.Users.AsNoTracking().FirstAsync(u => u.Id == id);
            return User.CreateUser(userEntity.Name, userEntity.Email, userEntity.Password, MapOperations(userEntity.Operations)).User;
        }
        public async Task<Guid> Create(User user)
        {
            UserEntity userEntity = new()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Operations = new()
            };

            await _dbContext.Users.AddAsync(userEntity);
            await _dbContext.SaveChangesAsync();

            return userEntity.Id;
        }
        public async Task<Guid> Update(Guid id, string name, string description,decimal amount, OperationType type)
        {
            //TODO fix mapping
            await _dbContext.Users
                .Where(u => u.Id == id)
                .ExecuteUpdateAsync(u => 
                    u.SetProperty(u => u.Operations.First(o => o.UserId == u.Id), 
                    u => MapOperation(Operation.Create(name,description,amount,u.Id,type).Operation)));

            return id;
        }
        public async Task<Guid> Delete(Guid id)
        {
            await _dbContext.Users
                .Where(u => u.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
        private List<Operation> MapOperations(List<OperationEntity> operationEntities)
        {
            List<Operation> operations = new List<Operation>();

            if (operationEntities != null && operationEntities.Count > 0)
            {
                foreach (OperationEntity entity in operationEntities)
                {
                    Operation operation = Operation.Create(entity.Name, entity.Description,entity.Amount, entity.UserId, entity.Type).Operation;

                    operations.Add(operation);
                }
            }

            return operations;
        }
        private OperationEntity MapOperation(Operation operation)
        {
            return new OperationEntity
            {
                Name = operation.Name,
                Description = operation.Description,
                Amount = operation.Amount,
                UserId = operation.UserId,
                Type = operation.Type,
            };
        }

        
    }
}
