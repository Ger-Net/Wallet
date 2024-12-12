using Google.LongRunning;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Wallet22.MVVM.Model;
using Wallet22.MVVM.View;
using Wallet22.Services;
using Wallet22.Services.UserServices;
using Operation = Wallet22.MVVM.Model.Operation;


namespace Wallet22.MVVM.ViewModel.Operations
{
    public class OperationView : BaseOperationVM
    {
        #region Props
        public SortDirection SortDirection { get; set; } = SortDirection.None;
        public SortColumn SortColumn { get; set; }

        private int _totalAmount;
        public int TotalAmount
        {
            get => _totalAmount;
            set
            {
                _totalAmount = value;
                OnPropertyChanged(nameof(TotalAmount));
            }
        }

        private int _totalIncreaseAmount;
        public int TotalIncreaseAmount
        {
            get => _totalIncreaseAmount;
            set
            {
                _totalIncreaseAmount = value;
                OnPropertyChanged(nameof(TotalIncreaseAmount));
            }
        }

        private int _totalDecreaseAmount;
        public int TotalDecreaseAmount
        {
            get => _totalDecreaseAmount;
            set
            {
                _totalDecreaseAmount = value;
                OnPropertyChanged(nameof(TotalDecreaseAmount));
            }
        }
        
        #endregion
        #region Commands
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand {  get; set; }
        public ICommand DeleteCommand { get; set; }
        public Command<SortDTO> SortCommand { get; set; }
        #endregion
        public ObservableCollection<Operation> Operations { get; private set; } = new();
        public OperationView(IUserService userService) : base(userService)
        {
            
            AddCommand = new Command(() =>
            {
                var op = new Operation(Date, Description, Type, Convert.ToInt32(Amount));
                Operations.Add(op);
                userService.Add(op);
                PropertyNulling();
                Calculate();
            },
            canExecute);
            EditCommand = new Command<Operation>(async (Operation operation) =>
            {
                await Shell.Current.Navigation.PushAsync(new OperationEditPage(operation, userService));
                Calculate();
            });
            DeleteCommand = new Command<Operation>((Operation operation) =>
            {
                userService.Remove(operation);
                Operations.Remove(operation);
                Calculate();
            });
            SortCommand = new Command<SortDTO>(Sort);
            Calculate();
        }
        public override void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            base.OnPropertyChanged(prop);
            ((Command)AddCommand).ChangeCanExecute();
        }
        public void Sort(SortDTO sortDTO)
        {
            var op = new List<Operation>(Operations);

            SortColumn = sortDTO.SortColumn;
            SortDirection = sortDTO.SortDirection;

            switch (SortColumn)
            {
                case SortColumn.Date:
                    op.Sort((x, y) =>
                        SortDirection == SortDirection.Ascending
                            ? x.Date.CompareTo(y.Date)
                            : y.Date.CompareTo(x.Date));
                    break;
                case SortColumn.Type:
                    op.Sort((x, y) =>
                        SortDirection == SortDirection.Ascending
                            ? x.Type.CompareTo(y.Type)
                            : y.Type.CompareTo(x.Type));
                    break;
                case SortColumn.Amount:
                    op.Sort((x, y) =>
                        SortDirection == SortDirection.Ascending
                            ? x.Amount.CompareTo(y.Amount)
                            : y.Amount.CompareTo(x.Amount));
                    break;
                case SortColumn.Description:
                    op.Sort((x, y) =>
                        SortDirection == SortDirection.Ascending
                            ? x.Description.CompareTo(y.Description)
                            : y.Description.CompareTo(x.Description));
                    break;
            }
            //Operations = new(op);
            Operations.Clear();
            foreach (var item in op)
            {
                Operations.Add(item);
            }
        }


        //TODO calculate only month
        private void Calculate()
        {
            TotalIncreaseAmount = Operations.Where(t => t.Type == "Доход").Sum(t => t.Amount);
            TotalDecreaseAmount = Operations.Where(t => t.Type == "Расход").Sum(t => t.Amount);

            TotalAmount = TotalIncreaseAmount - TotalDecreaseAmount;

        }
    }
}
