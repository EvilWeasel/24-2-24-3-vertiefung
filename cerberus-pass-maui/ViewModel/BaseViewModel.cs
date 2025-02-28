using CommunityToolkit.Mvvm.ComponentModel;

namespace cerberus_pass_maui.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor("IsNotBusy")]
        bool isBusy = false;

        [ObservableProperty]
        string title;

        public bool IsNotBusy => !IsBusy;
    }
}
