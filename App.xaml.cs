using Wallet22.MVVM.View.Auth;
using Wallet22.Services.UserServices;

namespace Wallet22
{

    public partial class App : Application
    {
        public App(IUserService userService)
        {
            InitializeComponent();

            MainPage = new LoginPage(userService);
        }
    }
}
