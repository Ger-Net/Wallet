using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Wallet22.MVVM.Model;

namespace Wallet22.MVVM.ViewModel
{
    public class OperationView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand AddCommand { get; set; }
        public ObservableCollection<Operation> Operations { get; } = new();

        private DateTime _date = DateTime.Now;
        private string _description;
        private string _type;
        private string _amount;

        public OperationView()
        {
            Func<bool> canExecute = () => !string.IsNullOrWhiteSpace(Description) &&
                              !string.IsNullOrWhiteSpace(Type) &&
                              !string.IsNullOrWhiteSpace(Type) &&
                              int.TryParse(Amount, out int result);

            AddCommand = new Command(() =>
            {
                Operations.Add(new Operation(Date, Description, Type, Convert.ToInt32(Amount)));
                PropertyNulling();
            },
            canExecute);
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                if(_date != value)
                {
                    _date = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                if(_description != value)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Type
        {
            get => _type;
            set
            {
                if( _type != value)
                {
                    _type = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Amount
        {
            get => _amount;
            set
            {
                if(_amount != value)
                {
                    _amount = value;
                    OnPropertyChanged();
                }
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            ((Command)AddCommand).ChangeCanExecute();
        }

        private void PropertyNulling()
        {
            Date = DateTime.Now;
            Description = "";
            Type = "";
            Amount = "";
        }
    }
}
