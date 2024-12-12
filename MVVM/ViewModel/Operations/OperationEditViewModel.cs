using System.Runtime.CompilerServices;
using System.Windows.Input;
using Wallet22.MVVM.Model;
using Wallet22.MVVM.ViewModel.Operations;
using Wallet22.Services;
using Wallet22.Services.UserServices;

namespace Wallet22.MVVM.ViewModel
{
    public class OperationEditViewModel : BaseOperationVM
    {
        public ICommand EditCommand { get; set; }
        public OperationEditViewModel(Operation operation, IUserService userService) : base(userService)
        {

            EditCommand = new Command(async () =>
            {
                operation.Date = Date;
                operation.Type = Type;
                operation.Amount = Convert.ToInt32(Amount);
                operation.Description = Description;

                userService.Update(
                    new() 
                    { 
                        Date = operation.Date, 
                        Amount = Convert.ToInt32(Amount), 
                        Type = operation.Type, 
                        Description = Description
                    });

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
