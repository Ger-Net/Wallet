using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wallet22.MVVM.Commons;
using Wallet22.MVVM.View;
using Wallet22.MVVM.View.Auth;
using Wallet22.Services.UserServices;

namespace Wallet22.MVVM.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand LoginCommand { get; set; }
        public ICommand RedirectToRegisterCommand { get; set; }

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        //TODO add Checks
        public LoginViewModel(IUserService userService)
        {
            LoginCommand = new Command(async () =>
            {
                UserDTO userDTO = new UserDTO() { Login = Username, Password = Password };
                if (await userService.TryLogIn(userDTO))
                    Application.Current.MainPage = new AppShell();
                else
                    return;
                
            },
            () =>
            {
                return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
            });
            RedirectToRegisterCommand = new Command(async () =>
            {
                Application.Current.MainPage = new RegisterPage(userService);
            });
        }

        public virtual void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            ((Command)LoginCommand).ChangeCanExecute();
        }
    }
}
