
using System.Collections.ObjectModel;

namespace maui_cerberus_pass;
public partial class MainPage : ContentPage
{
    public ObservableCollection<PasswordEntry> Entries { get; set; } = [];
    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
        Entries.Add(new PasswordEntry(
            "github-privat",
            "evilweasel",
            "P@ssword"
        ));
        Entries.Add(new PasswordEntry(
            "github-arbeit",
            "boilerplatesharp",
            "P@ssword"
        ));
        Entries.Add(new PasswordEntry(
            "steam",
            "evilweasel",
            "P@ssword"
        ));
        Entries.Add(new PasswordEntry(
            "gog",
            "waldmeistersd",
            "P@ssword"
        ));
    }
}