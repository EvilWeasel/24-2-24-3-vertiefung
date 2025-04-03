using CommunityToolkit.Mvvm.ComponentModel;

namespace BuchverkaufBinder.ViewModel;

public partial class BaseViewModel : ObservableValidator
{
    [ObservableProperty]
    string title = "Default Title";
}
