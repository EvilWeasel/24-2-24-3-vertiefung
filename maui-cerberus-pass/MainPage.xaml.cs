﻿
using System.Collections.ObjectModel;

namespace maui_cerberus_pass;
public partial class MainPage : ContentPage
{
    private readonly ObservableCollection<PasswordEntry> entries = [];
    public ObservableCollection<PasswordEntry> FilteredEntries { get; set; } = [];
    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
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
        entries.Add(new PasswordEntry(
    "gog",
    "waldmeistersd",
    "P@ssword"
));
        entries.Add(new PasswordEntry(
    "gog",
    "waldmeistersd",
    "P@ssword"
));
        entries.Add(new PasswordEntry(
    "gog",
    "waldmeistersd",
    "P@ssword"
));
        entries.Add(new PasswordEntry(
    "gog",
    "waldmeistersd",
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

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
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
}