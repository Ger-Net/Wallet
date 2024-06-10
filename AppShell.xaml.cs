namespace Wallet22
{
    public partial class AppShell : Shell
    {
        private IUserService _userService;
        public AppShell(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }
    }
}
