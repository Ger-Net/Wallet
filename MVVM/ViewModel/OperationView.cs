using Google.LongRunning;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Wallet22.MVVM.Model;
using Wallet22.MVVM.View;
using Wallet22.Services;
using Operation = Wallet22.MVVM.Model.Operation;


namespace Wallet22.MVVM.ViewModel
{
    public class OperationView : BaseOperationVM
    {
        public SortDirection SortDirection { get; set; } = SortDirection.None;
        public SortColumn SortColumn { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand {  get; set; }
        public ICommand DeleteCommand { get; set; }
        public Command<SortDTO> SortCommand { get; set; }
        public ObservableCollection<Operation> Operations { get; private set; } = new();
        
        public OperationView() : base()
        {
            using (var db = new UserInAppDB())
            {
                Operations = db.Load();
            }
            AddCommand = new Command(() =>
            {
                var op = new Operation(Date, Description, Type, Convert.ToInt32(Amount));
                Operations.Add(op);
                using(var db = new UserInAppDB())
                {
                    db.Operations.Add(op);
                    db.SaveChanges();
                }
                PropertyNulling();
            },
            canExecute);
            EditCommand = new Command<Operation>(async (Operation operation) =>
            {
                await Shell.Current.Navigation.PushAsync(new OperationEditPage(operation));

            });
            DeleteCommand = new Command<Operation>((Operation operation) =>
            {
                using (var db = new UserInAppDB())
                {
                    db.Operations.Remove(operation);
                    db.SaveChanges();
                }
                Operations.Remove(operation);
                
            });
            SortCommand = new Command<SortDTO>(Sort);
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
    }
}
