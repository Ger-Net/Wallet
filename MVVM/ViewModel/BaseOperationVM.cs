using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wallet22.MVVM.ViewModel
{
    public abstract class BaseOperationVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected Func<bool> canExecute;
        protected DateTime _date = DateTime.Now;
        protected string _description;
        protected string _type;
        protected string _amount;

        public BaseOperationVM()
        {
            canExecute = () =>
            {
                return !string.IsNullOrWhiteSpace(Description) &&
                                              !string.IsNullOrWhiteSpace(Type) &&
                                              int.TryParse(Amount, out int result);
            };
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                if (_date != value)
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
                if (_description != value)
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
                if (_type != value)
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
                if (_amount != value)
                {
                    _amount = value;
                    OnPropertyChanged();
                }
            }
        }

        

        public virtual void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        protected void PropertyNulling()
        {
            Date = DateTime.Now;
            Description = "";
            Type = "";
            Amount = "";
        }
    }
}
