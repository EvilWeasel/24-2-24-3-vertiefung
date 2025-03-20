using CommunityToolkit.Mvvm.Input;
using maui_cerberus_pass.Views;
using password_manager_toolkit;
using System.Collections.ObjectModel;

namespace maui_cerberus_pass.ViewModels;

[QueryProperty(nameof(Refresh), "Refresh")]
public partial class MainViewModel : BaseViewModel
{
    private const string masterpass = "P@ssword";
    private readonly PasswordManager manager;
    // [ObservableProperty]
    // private ObservableCollection<PasswordEntry> entries = [];
    public ObservableCollection<PasswordEntry> FilteredEntries { get; set; } = [];

    /* Implementierung der Suche über Text Property Binding und Seach-Function Call im Setter */
    string searchText = string.Empty;
    public string SearchText
    {
        get => searchText;
        set
        {
            if (value != searchText)
            {
                OnPropertyChanging();
                searchText = value;
                Search(value);
                OnPropertyChanged();
            }
        }
    }

    public bool Refresh { set => ReloadVault(); }

    public MainViewModel(PasswordManager _manager)
    {
        manager = _manager;
        Title = "Vault";

        manager.LoadVault(masterpass);

        // Entries = new ObservableCollection<PasswordEntry>(manager.GetAll());
        //entries = [.. manager.GetAll()];

        // FilteredEntries = new ObservableCollection<PasswordEntry>(Entries);
        foreach (var entry in manager.GetAll())
        {
            FilteredEntries.Add(entry);
        }
    }

    [RelayCommand]
    public void Search(string searchText)
    {
        FilteredEntries.Clear();
        foreach (var entry in manager.GetAll())
        {
            if (entry.Title.Contains(searchText,
                    StringComparison.InvariantCultureIgnoreCase))
                FilteredEntries.Add(entry);
        }
    }

    [RelayCommand]
    public async Task GoToDetails(object param)
    {
        if (param is PasswordEntry selectedEntry)
        {
            // $"{nameof(DetailsPage)}" => "DetailsPage"
            await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", true,
            new Dictionary<string, object>
            {
                {"Entry",  new PasswordEntry(
                    selectedEntry.Title,
                    selectedEntry.Login,
                    selectedEntry.Password,
                    selectedEntry.Website,
                    selectedEntry.Note
                    )},
                {"TitleToChange", selectedEntry.Title }
            });
        }
    }

    [RelayCommand]
    public async Task GoToNewEntry()
    {
        await Shell.Current.GoToAsync($"{nameof(AddEntryPage)}", true);
    }

    private void ReloadVault()
    {
        FilteredEntries.Clear();
        foreach (var entry in manager.GetAll())
        {
            FilteredEntries.Add(entry);
        }
    }

    [RelayCommand]
    public async Task DeleteEntry(object param)
    {
        if (param is PasswordEntry entry)
        {
            var masterpass = await Shell.Current.DisplayPromptAsync(
                "Enter Masterpass", "Verify your MasterPassword to continue");
            if (masterpass is not null && manager.VerifyMasterPass(masterpass))
            {
                if (manager.DeleteEntry(masterpass, entry.Title))
                    ReloadVault();
                else
                    await Shell.Current.DisplayAlert("Error",
                        $"Entry {entry.Title} could not be deleted", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error",
                    "MasterPassword is not correct!", "Ok");
            }
        }
    }
}
