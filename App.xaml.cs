using Wallet22.MVVM.View.Auth;

namespace Wallet22
{
    
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            Shell.Current.Navigation.PushAsync(new LoginPage());
        }
    }
}
