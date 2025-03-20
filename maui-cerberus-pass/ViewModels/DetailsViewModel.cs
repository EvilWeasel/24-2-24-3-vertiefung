using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using password_manager_toolkit;

namespace maui_cerberus_pass.ViewModels;

[QueryProperty(nameof(Entry), "Entry")]
[QueryProperty(nameof(TitleToChange), "TitleToChange")]
public partial class DetailsViewModel : BaseViewModel
{
    public string TitleToChange { get; set; } = "";
    [ObservableProperty]
    PasswordEntry? entry;

    PasswordManager manager;

    public DetailsViewModel(PasswordManager manager)
    {
        this.manager = manager;
    }

    [RelayCommand]
    public async Task NavigateBack()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    public async Task UpdateEntry()
    {
        var masterpass = await Shell.Current.DisplayPromptAsync(
            "Enter Masterpass", "Verify your MasterPassword to continue");
        manager.UpdateEntry(
            masterpass,
            TitleToChange,
            Entry);
        await Shell.Current.GoToAsync("..?Refresh=True");
    }
}
