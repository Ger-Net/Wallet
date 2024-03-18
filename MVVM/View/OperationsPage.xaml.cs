using Wallet22.MVVM.ViewModel;

namespace Wallet22.MVVM.View;

public partial class OperationsPage : ContentPage
{
	public OperationsPage()
	{
        InitializeComponent();
		BindingContext = new OperationView();
	}
}