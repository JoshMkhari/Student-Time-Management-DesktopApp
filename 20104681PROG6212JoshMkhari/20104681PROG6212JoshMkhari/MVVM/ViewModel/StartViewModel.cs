using _20104681PROG6212JoshMkhari.Commands;
using System.Windows.Input;

namespace _20104681PROG6212JoshMkhari.MVVM.ViewModel
{
    public class StartViewModel : BaseViewModel
    {
        public ICommand UpdateViewCommand { get; set; }

        public StartViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
        }
    }
}
