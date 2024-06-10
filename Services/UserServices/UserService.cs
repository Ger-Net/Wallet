using System.Collections.ObjectModel;
using Wallet22.MVVM.Model;

namespace Wallet22.Services.UserServices
{
    public class UserService : IUserService
    {
        private User _user;

        public User GetCurrentUser()
        {
            return _user;
        }
        public ObservableCollection<Operation> GetOperations()
        {
            return new(_user.Operations);
        }
        public Task<bool> Login(string username, string password)
        {
            using(UserDB context =  new UserDB())
            {
                User user = context.Users.First(t => t.Name == username && t.Password == password);
                if (user != null)
                {
                    _user = user;
                    return Task.FromResult(true);
                }
            }
            return Task.FromResult(false);
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(string username, string password)
        {
            User user = new User();
            user.Init(username, password);
            try
            {
                using(UserDB context =  new UserDB())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}
