using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using password_manager_toolkit;
using maui_cerberus_pass.Views;

namespace maui_cerberus_pass.ViewModels;

[QueryProperty(nameof(Refresh), "Refresh")]
public partial class MainViewModel : BaseViewModel
{
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
        
        //manager.LoadVault(masterpass);

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
    public async Task CopyPasswordToClipboard(object param)
    {
        if (param is PasswordEntry selectedEntry)
            await Clipboard.SetTextAsync(selectedEntry.Password);
    }
}
