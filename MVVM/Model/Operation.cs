using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Wallet22.MVVM.Model
{
    public class Operation : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private DateTime _date;
        private string _description;
        private string _type;
        private int _amount;

        [Key]
        public Guid ID { get; set; }
        public User User { get; set; }
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
                if(_type != value)
                {
                    _type = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Amount
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

        public Operation(DateTime date,string description, string type, int amount) 
        {
            ID = Guid.NewGuid();
            Date = date;
            Description = description;
            Type = type;
            Amount = amount;
        }
        public Operation()
        {
            ID = Guid.NewGuid();
            Date = DateTime.Now;
            Description = "";
            Type = "";
            Amount = 0;
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
