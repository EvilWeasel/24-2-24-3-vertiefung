using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using password_manager_toolkit;

namespace maui_cerberus_pass.ViewModels;

[QueryProperty(nameof(Entry), "Entry")]
public partial class DetailsViewModel : BaseViewModel
{
    [ObservableProperty]
    PasswordEntry? entry;

    [RelayCommand]
    public async Task NavigateBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}
