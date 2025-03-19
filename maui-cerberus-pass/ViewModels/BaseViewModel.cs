using CommunityToolkit.Mvvm.ComponentModel;

namespace maui_cerberus_pass.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    string title = "Default Title";
}
