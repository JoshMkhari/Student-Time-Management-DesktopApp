using _20104681PROG6212JoshMkhari.Commands;
using System.Windows.Input;

namespace _20104681PROG6212JoshMkhari.MVVM.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand UpdateViewCommand { get; set; }

        public LoginViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
        }
    }
}
