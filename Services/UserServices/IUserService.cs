using System.Collections.ObjectModel;
using Wallet22.MVVM.Model;

public interface IUserService
{
    Task<bool> Login(string username, string password);
    Task<bool> Register(string username, string password);
    User GetCurrentUser();
    void Logout();
    ObservableCollection<Operation> GetOperations();
}
