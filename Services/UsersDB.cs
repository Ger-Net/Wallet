using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using Wallet22.MVVM.Commons;
using Wallet22.MVVM.Model;

namespace Wallet22.Services
{
    public class UsersDb : DbContext
    {
        private User _currentUser;
        private DbSet<User> _users => Set<User>();
        public DbSet<Operation> Operations => Set<Operation>();

        public UsersDb()
        {
            Database.EnsureCreated();
        }
        public bool LogIn(UserDTO user)
        {
            if(_users.Any(t=> t.Login == user.Login && t.Password == user.Password))
            {
                _currentUser = _users.First(t => t.Login == user.Login && t.Password == user.Password);
                return true;
            }
            return false;
        }
        public void Register(UserDTO user)
        {
            User newUser = new User()
            {
                Id = Guid.NewGuid(),
                Login = user.Login,
                Email = user.Email,
                Password = user.Password,
                Operations = new(),
                Friends = new()
            };
            _users.Add(newUser);
            SaveChanges();
        }
        public ObservableCollection<Operation> Load()
        {
            ObservableCollection<Operation> operations = [.. _currentUser.Operations];

            return operations;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}\\op.db");
        }
    }
}
