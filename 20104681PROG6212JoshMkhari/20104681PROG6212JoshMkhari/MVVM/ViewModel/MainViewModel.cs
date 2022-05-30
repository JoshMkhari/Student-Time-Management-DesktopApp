using _20104681PROG6212JoshMkhari.Commands;
using System.Windows.Input;

namespace _20104681PROG6212JoshMkhari.MVVM.ViewModel
{
    public class MainViewModel : BaseViewModel //Home page Controller
    {
        private BaseViewModel _currentView;
        public static string radioButtonName = "";
        public BaseViewModel SelectedViewModel
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand UpdateViewCommand { get; set; }

        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
        }

        public static void setCheckRadioButton(string name)
        {
            radioButtonName = name;
        }

        public static string getCheckRadioButton()
        {
            return radioButtonName;
        }
    }
}
