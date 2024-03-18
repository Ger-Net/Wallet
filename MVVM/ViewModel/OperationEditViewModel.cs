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
            Date = operation.Date;
            Type = operation.Type;
            Amount = operation.Amount.ToString();
            Description = operation.Description;
            EditCommand = new Command(() =>
            {

            },
            canExecute);
        }
        public override void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            base.OnPropertyChanged(prop);
        }
    }
}
