using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using maui_cerberus_pass.Models;
using maui_cerberus_pass.Views;

namespace maui_cerberus_pass.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private readonly ObservableCollection<PasswordEntry> entries = [];
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

    public MainViewModel()
    {
        Title = "Vault";
        entries.Add(new PasswordEntry(
            "github-privat",
            "evilweasel",
            "P@ssword"
        ));
        entries.Add(new PasswordEntry(
            "github-arbeit",
            "boilerplatesharp",
            "P@ssword"
        ));
        entries.Add(new PasswordEntry(
            "steam",
            "evilweasel",
            "P@ssword"
        ));
        entries.Add(new PasswordEntry(
            "gog",
            "waldmeistersd",
            "P@ssword"
        ));
        // FilteredEntries = new ObservableCollection<PasswordEntry>(Entries);
        foreach (var entry in entries)
        {
            FilteredEntries.Add(entry);
        }
    }

    [RelayCommand]
    public void Search(string searchText)
    {
        FilteredEntries.Clear();
        foreach (var entry in entries)
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
                    )}
            });
        }
    }
}
