using Wallet22.MVVM.ViewModel.Auth;
using Wallet22.Services.UserServices;

namespace Wallet22.MVVM.View.Auth;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(IUserService userService)
	{
		InitializeComponent();
		BindingContext = new RegisterViewModel(userService);
	}
}