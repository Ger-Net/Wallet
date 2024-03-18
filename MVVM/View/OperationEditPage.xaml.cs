using Wallet22.MVVM.Model;

namespace Wallet22.MVVM.View;

public partial class OperationEditPage : ContentPage
{
	public Operation Operation { get; set; }
	public OperationEditPage(Operation? operation)
	{
		InitializeComponent();

		if (operation == null)
		{
			operation = new Operation();
		}
		Operation = operation;
		BindingContext = Operation;
	}
}