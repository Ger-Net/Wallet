using Wallet22.MVVM.ViewModel;

namespace Wallet22.MVVM.View.Auth;

public partial class LoginPage : ContentPage
{
	public LoginPage(IUserService userService)
	{
		InitializeComponent();
		BindingContext = new LoginViewModel(userService);
    }
}