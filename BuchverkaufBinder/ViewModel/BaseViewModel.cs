using CommunityToolkit.Mvvm.ComponentModel;

namespace BuchverkaufBinder.ViewModel;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    string title = "Default Title";
}
