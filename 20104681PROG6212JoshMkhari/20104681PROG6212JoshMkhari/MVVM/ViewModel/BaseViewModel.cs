using System.ComponentModel;

namespace _20104681PROG6212JoshMkhari.MVVM.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
