using _20104681PROG6212JoshMkhari.Commands;
using System.Windows.Input;

namespace _20104681PROG6212JoshMkhari.MVVM.ViewModel
{
    public class ModuleAdderViewModel : BaseViewModel
    {
        public ICommand UpdateViewCommand { get; set; }

        public ModuleAdderViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
        }
    }
}
