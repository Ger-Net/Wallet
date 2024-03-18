using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet22.MVVM.Model;

namespace Wallet22.MVVM.ViewModel
{
    public class OperationEditViewModel : BaseOperationVM, INotifyPropertyChanged
    {
        private Operation _operation;
        public event PropertyChangedEventHandler? PropertyChanged;
        public OperationEditViewModel(Operation operation)
        {
            _operation = operation;
        }

    }
}
