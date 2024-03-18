using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wallet22.MVVM.Model;

namespace Wallet22.MVVM.ViewModel
{
    public class OperationEditViewModel : BaseOperationVM
    {
        public ICommand EditCommand { get; set; }
        public OperationEditViewModel(Operation operation)
        {
            _date = operation.Date;
            _type = operation.Type;
            _amount = operation.Amount.ToString();
            _description = operation.Description;
            EditCommand = new Command(async () =>
            {
                operation.Date = _date;
                operation.Type = _type;
                operation.Amount = Convert.ToInt32(_amount);
                operation.Description = _description;
                await Shell.Current.Navigation.PopAsync();
            },
            canExecute);
        }
        public override void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            base.OnPropertyChanged(prop);
            ((Command)EditCommand).ChangeCanExecute();
        }
    }
}
