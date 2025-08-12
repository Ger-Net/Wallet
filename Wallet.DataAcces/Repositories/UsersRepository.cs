using Microsoft.EntityFrameworkCore;
using Wallet.Core.Models;
using Wallet.Core.DataBases;
using Wallet.Core.Entities;

namespace Wallet.Core.Abstract
{
    public class UsersRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UsersRepository(AppDbContext dbContext)
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
        public async Task<Guid> Update(Guid id, string name, string email, string password)
        {
            await _dbContext.Users
                .Where(u => u.Id == id)
                .ExecuteUpdateAsync(u =>
                    u.SetProperty(u => u.Name, u => name)
                    .SetProperty(u => u.Email, u => email)
                    .SetProperty(u => u.Password, u => password));

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
                    User user = User.CreateUser(entity.User.Name, entity.User.Email, entity.User.Password, new()).User;
                    Operation operation = Operation.Create(entity.Name, entity.Description,entity.Amount, user, entity.Type).Operation;

                    operations.Add(operation);
                }
            }

            return operations;
        }     
    }
}
