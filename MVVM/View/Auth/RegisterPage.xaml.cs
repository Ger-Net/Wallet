using Wallet22.MVVM.ViewModel;

namespace Wallet22.MVVM.View.Auth;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(IUserService userService)
	{
		InitializeComponent();
        BindingContext = new LoginViewModel(userService);

    }
}