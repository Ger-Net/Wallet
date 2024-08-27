using Wallet22.MVVM.ViewModel;
using Wallet22.Services.UserServices;

namespace Wallet22.MVVM.View.Auth;

public partial class LoginPage : ContentPage
{
	public LoginPage(IUserService userService)
	{
		InitializeComponent();
		BindingContext = new LoginViewModel(userService);
	}
}