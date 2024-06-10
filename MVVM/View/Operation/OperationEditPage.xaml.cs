using Wallet22.MVVM.Model;
using Wallet22.MVVM.ViewModel;

namespace Wallet22.MVVM.View;

public partial class OperationEditPage : ContentPage
{
	public Operation Operation { get; set; }
	public OperationEditPage(Operation? operation, IUserService userService)
	{
		InitializeComponent();

		if (operation == null)
		{
			operation = new Operation();
		}
		Operation = operation;
		BindingContext = new OperationEditViewModel(Operation,userService);
	}
}