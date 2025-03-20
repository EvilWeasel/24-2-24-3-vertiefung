using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using password_manager_toolkit;

namespace maui_cerberus_pass.ViewModels;

public partial class AddEntryViewModel : BaseViewModel
{
    private const string masterpass = "P@ssword";
    [ObservableProperty]
    PasswordEntry entry;

    PasswordManager manager;

    public AddEntryViewModel(PasswordManager manager)
    {
        entry = new PasswordEntry(
            string.Empty,string.Empty,string.Empty);
        this.manager = manager;
    }
    [RelayCommand]
    public async Task AddEntry()
    {
        manager.CreateEntry(
            masterpass,
            Entry.Title,
            Entry.Login,
            Entry.Password,
            Entry.Website,
            Entry.Note);
        await Shell.Current.GoToAsync("..?Refresh=True");
    }
}
