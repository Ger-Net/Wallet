using System.Collections.ObjectModel;
using Wallet22.MVVM.Model;
using Wallet22.MVVM.Commons;

namespace Wallet22.Services.UserServices
{
    public interface IUserService
    {
        Task<bool> TryLogIn(UserDTO userDTO);
        
        ObservableCollection<Operation> Load();

        void Add(Operation operation);
        void Remove(Operation operation);

        void Update(Operation operation);
        
    }
}
