using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;

namespace maui_mvvm.ViewModel;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private string text;
}
