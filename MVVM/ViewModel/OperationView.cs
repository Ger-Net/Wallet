﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Wallet22.MVVM.Model;
using Wallet22.MVVM.View;


namespace Wallet22.MVVM.ViewModel
{
    public class OperationView : BaseOperationVM
    {
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand {  get; set; }
        public ICommand DeleteCommand { get; set; }
        public ObservableCollection<Operation> Operations { get; } = new();
        
        public OperationView() : base()
        {
            
            AddCommand = new Command(() =>
            {
                Operations.Add(new Operation(Date, Description, Type, Convert.ToInt32(Amount)));
                PropertyNulling();
            },
            canExecute);
            EditCommand = new Command<Operation>(async (Operation operation) =>
            {
                await Shell.Current.Navigation.PushAsync(new OperationEditPage(operation));

            });
            DeleteCommand = new Command<Operation>((Operation operation) =>
            {
                Operations.Remove(operation);
            });
        }
        public override void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            base.OnPropertyChanged(prop);
            ((Command)AddCommand).ChangeCanExecute();
        }

    }
}
