using CommunityToolkit.Mvvm.ComponentModel;
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

    public async Task AddEntry()
    {
        manager.CreateEntry(
            masterpass,
            Entry.Title,
            Entry.Login,
            Entry.Password,
            Entry.Website,
            Entry.Note);
    }
}
