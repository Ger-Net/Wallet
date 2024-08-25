using System.Runtime.CompilerServices;
using System.Windows.Input;
using Wallet22.MVVM.Model;
using Wallet22.Services;

namespace Wallet22.MVVM.ViewModel
{
    public class OperationEditViewModel : BaseOperationVM
    {
        public ICommand EditCommand { get; set; }
        public OperationEditViewModel(Operation operation) : base()
        {
            
            EditCommand = new Command(async () =>
            {
                operation.Date = Date;
                operation.Type = Type;
                operation.Amount = Convert.ToInt32(Amount);
                operation.Description = Description;

                using (var db = new UserInAppDB())
                {
                    var id = operation.ID;
                    var op = db.Operations.FirstOrDefault(t => t.ID == id);
                    op.Date = operation.Date;
                    op.Type = operation.Type;
                    op.Amount = Convert.ToInt32(Amount);
                    op.Description = Description;
                    db.SaveChanges();
                }

                await Shell.Current.Navigation.PopAsync();
            },
            canExecute);
            _date = operation.Date;
            _type = operation.Type;
            _amount = operation.Amount.ToString();
            _description = operation.Description;
            
        }
        public override void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            base.OnPropertyChanged(prop);
            ((Command)EditCommand).ChangeCanExecute();
        }
    }
}
