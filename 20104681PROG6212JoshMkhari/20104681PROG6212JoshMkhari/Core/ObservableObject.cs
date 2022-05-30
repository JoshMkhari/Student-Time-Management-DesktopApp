
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _20104681PROG6212JoshMkhari.Core
{
    class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
