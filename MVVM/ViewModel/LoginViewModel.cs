using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wallet22.MVVM.View;

namespace Wallet22.MVVM.ViewModel
{
    public class LoginViewModel
    {
        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () =>
            {
                await Shell.Current.Navigation.PushAsync(new OperationsPage());
            });
        }
    }
}
