using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Wallet22.MVVM.Model;
using Wallet22.MVVM.View;
using Wallet22.Services;


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
        }
        public override void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            base.OnPropertyChanged(prop);
            ((Command)AddCommand).ChangeCanExecute();
        }

    }
}
