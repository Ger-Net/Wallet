using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Wallet22.MVVM.Commons;
using Wallet22.MVVM.View.Auth;
using Wallet22.Services.UserServices;

namespace Wallet22.MVVM.ViewModel.Auth
{
    class RegisterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand RegisterCommand { get; set; }
        public ICommand BackToLoginCommand { get; set; }

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
        private string _confirmPassword;
        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }

        public bool IncorrectPassword { get; private set; } = false;
        public bool UserExist { get; private set; } = false;
        public RegisterViewModel(IUserService userService)
        {
            RegisterCommand = new Command(async () =>
            {
                IncorrectPassword = false;
                UserDTO userDTO = new UserDTO() { Login = Username, Password = Password };
                if (!await userService.TryRegister(userDTO))
                {
                    UserExist = true;
                    return;
                }
                Application.Current.MainPage = new LoginPage(userService);
            }, () => 
            {
                if (Password != ConfirmPassword)
                    IncorrectPassword = true;
                return !string.IsNullOrWhiteSpace(Username) && (Password == ConfirmPassword);
            });

            BackToLoginCommand = new Command(() =>
            {
                Application.Current.MainPage = new LoginPage(userService);
            });
        }

        public virtual void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            ((Command)RegisterCommand).ChangeCanExecute();
        }

        
    }
}
