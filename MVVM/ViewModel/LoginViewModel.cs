using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Wallet22.MVVM.Model;
using Wallet22.MVVM.View;
using Wallet22.MVVM.View.Auth;

namespace Wallet22.MVVM.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged, IExecutable
    {
        private string _userName;
        private string _password;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand LoginCommand { get; set; }
        public ICommand OpenRegisterCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public string UserName
        {
            get => _userName;
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if( _password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }

        public Func<bool> CanExecute { get; init; }
        public bool InvalidData { get; set; } = false;
        public LoginViewModel(IUserService userService)
        {
            CanExecute = () =>
            {
                return !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password) && Password.Length > 6;
            };

            LoginCommand = new Command(async () =>
            {
                if (await userService.Login(UserName, Password))
                {
                    await Shell.Current.Navigation.PushAsync(new AppShell(userService));
                }
                else
                {
                    InvalidData = true;
                }
            }, CanExecute);

            OpenRegisterCommand = new Command( async () =>
            {
                await Shell.Current.Navigation.PushAsync(new RegisterPage(userService));
                
            });
            BackCommand = new Command(async () =>
            {
                await Shell.Current.Navigation.PopAsync();
            });
            RegisterCommand = new Command(async () =>
            {
                if (await userService.Register(UserName, Password))
                    BackCommand.Execute(null);

            }, CanExecute);
            
        }

        public virtual void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
