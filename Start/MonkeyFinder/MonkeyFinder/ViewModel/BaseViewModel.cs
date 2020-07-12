using MonkeyFinder.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace MonkeyFinder.ViewModel
{

    public class BaseViewModel : INotifyPropertyChanged
    {
        bool isBusy;
        string title;

        public string Title
        {
            get => title;
            set
            {
                if (title == value)
                    return;
                title = value;
                OnPropertyChaged();
            }
        }
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (isBusy == value)
                    return;
                isBusy = value;
                OnPropertyChaged();
                OnPropertyChaged(nameof(IsNotBusy));

            }
        }

        public bool IsNotBusy => !IsBusy;

        public event PropertyChangedEventHandler PropertyChanged;
        // Use visor for Android physical device emulation
        // Use reflector for IOS physical device emulation

        void OnPropertyChaged([CallerMemberName]string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));   
    }
}
