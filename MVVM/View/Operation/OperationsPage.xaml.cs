using Microsoft.Maui.Controls;
using System.Drawing;
using Wallet22.MVVM.ViewModel;

namespace Wallet22.MVVM.View;

public partial class OperationsPage : ContentPage
{
    private OperationView _viewModel;
	public OperationsPage()
	{
        InitializeComponent();
        _viewModel = new OperationView();
		BindingContext = _viewModel;
	}

    private void OnDateTapped(object sender, TappedEventArgs e)
    {
        SortDirection direction = SortDirection.Ascending;
        SortColumn column = SortColumn.Date;
        Sort(direction, column);
    }
    private void OnTypeTapped(object sender, TappedEventArgs e)
    {
        SortDirection direction = SortDirection.Ascending;
        SortColumn column = SortColumn.Type;
        Sort(direction, column);

    }
    private void OnSumTapped(object sender, TappedEventArgs e)
    {
        SortDirection direction = SortDirection.Ascending;
        SortColumn column = SortColumn.Amount;
        Sort(direction, column);

    }
    private void OnDescTapped(object sender, TappedEventArgs e)
    {
        SortDirection direction = SortDirection.Ascending;
        SortColumn column = SortColumn.Description;
        
        Sort(direction, column);
    }

    private void Sort(SortDirection direction, SortColumn column)
    {
        if (_viewModel.SortColumn != column)
        {
            direction = SortDirection.Ascending;
        }
        if (_viewModel.SortDirection == SortDirection.Ascending)
        {
            direction = SortDirection.Descending;
        }
        _viewModel.SortCommand.Execute(new SortDTO(direction,column));
    }

}