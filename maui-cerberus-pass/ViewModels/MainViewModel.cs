using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using maui_cerberus_pass.Models;

namespace maui_cerberus_pass.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private readonly ObservableCollection<PasswordEntry> entries = [];
    public ObservableCollection<PasswordEntry> FilteredEntries { get; set; } = [];

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
    public void Search(object sender)
    {
        var searchBar = (SearchBar)sender;
        var searchText = searchBar.Text!;

        FilteredEntries.Clear();
        foreach (var entry in entries)
        {
            if (entry.Title.Contains(searchText,
                    StringComparison.InvariantCultureIgnoreCase))
                FilteredEntries.Add(entry);
        }
    }

    [RelayCommand]
    public async Task GoToDetails()
    {
        //if (e.Parameter is PasswordEntry selectedEntry)
        //{
        //    await Shell.Current.GoToAsync($"//DetailsPage", true,
        //    new Dictionary<string, object>
        //    {
        //        {"Entry",  selectedEntry}
        //    });
        //}
    }
}
