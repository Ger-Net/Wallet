using Wallet22.MVVM.View.Auth;

namespace Wallet22
{
    
    public partial class App : Application
    {
        private IUserService _userService;
        public App(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
            //TODO
            MainPage = new AppShell(_userService);
            
        }
    }
}
