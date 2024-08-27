using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet22.MVVM.Commons;
using Wallet22.MVVM.Model;

namespace Wallet22.Services.UserServices
{
    public class UserService : IUserService
    {
        private User _currentUser;

        public async Task<bool> TryLogIn(UserDTO user)
        {
            using (UsersDb db = new UsersDb())
            {
                if (await db.Users.AnyAsync(t => t.Login == user.Login && t.Password == user.Password))
                {
                    _currentUser = await db.Users.FirstAsync(t => t.Login == user.Login && t.Password == user.Password);
                    return true;
                }
                db.Users.Add(new() { Password = "123", Login = "1234", Id = Guid.NewGuid() });
                await db.SaveChangesAsync();
                return false;
            }

        }
        public ObservableCollection<Operation> Load()
        {
            ObservableCollection<Operation> operations = [.. _currentUser.Operations];

            return operations;
        }

        public void Register(UserDTO user)
        {
            User newUser = new User()
            {
                Id = Guid.NewGuid(),
                Login = user.Login,
                //Email = user.Email,
                Password = user.Password,
                Operations = new(),
                Friends = new()
            };
            using (UsersDb db = new UsersDb())
            {
                db.Users.Add(newUser);
                db.SaveChanges();
            }

        }

        public void Add(Operation operation)
        {
            _currentUser.Operations.Add(operation);
            using (UsersDb db = new UsersDb())
            {
                db.Users.First(t=> t.Id == _currentUser.Id).Operations.Add(operation);
                db.SaveChanges();
            }
        }

        public void Remove(Operation operation)
        {
            _currentUser.Operations.Remove(operation);
            using (UsersDb db = new UsersDb())
            {
                db.Users.First(t => t.Id == _currentUser.Id).Operations.Remove(operation);
                db.SaveChanges();
            }
        }
        public void Update(Operation operation)
        {
            using (UsersDb db = new UsersDb())
            {
                var id = operation.ID;
                var op = _currentUser.Operations.FirstOrDefault(t => t.ID == id);
                op.Date = operation.Date;
                op.Type = operation.Type;
                op.Amount = operation.Amount;
                op.Description = operation.Description;
                db.SaveChanges();
            }
            
        }
    }
}
