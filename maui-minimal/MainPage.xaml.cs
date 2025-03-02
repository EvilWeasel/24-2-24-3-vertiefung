using password_manager;
using System.Collections.ObjectModel;

namespace maui_minimal
{
    public partial class MainPage : ContentPage
    {
        readonly PasswordManager manager = PasswordManager.Instance;
        public ObservableCollection<PasswordEntry> Entries { get; set; }
            = new();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            Entries.Add(new PasswordEntry(
            "steam",
            "evilweasel",
            "P@ssword",
            "https://store.steampowered.com",
            "Hier könnte Ihre Werbung stehen!"));
            Entries.Add(new PasswordEntry(
                "gog",
                "evilweasel",
                "P@ssword",
                "https://gog.com",
                "Ich bin alt... soooo alt..."));
            Entries.Add(new PasswordEntry(
                "fritz box",
                "evilweasel",
                "P@ssword",
                "192.168.178.1",
                "It hurts when IP"));
        }
        public void AddEntry(object sender, EventArgs e)
        {
            Entries.Add(new PasswordEntry(
                "arena.net",
                "jürgen-würger",
                "P@ssword",
                "https://arena.net",
                "Fashion Wars 2"));
        }
    }

}
