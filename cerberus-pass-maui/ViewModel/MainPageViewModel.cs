using CommunityToolkit.Mvvm.Input;
using password_manager;
using System.Collections.ObjectModel;

namespace cerberus_pass_maui.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<PasswordEntry> PasswordEntries { get; } = new();
        public MainPageViewModel()
        {
            Title = "Passwörter";
            PasswordEntries.Add(new PasswordEntry(
            "steam",
            "evilweasel",
            "P@ssword",
            "https://store.steampowered.com",
            "Hier könnte Ihre Werbung stehen!"));
            PasswordEntries.Add(new PasswordEntry(
                "gog",
                "evilweasel",
                "P@ssword",
                "https://gog.com",
                "Ich bin alt... soooo alt..."));
            PasswordEntries.Add(new PasswordEntry(
                "fritz box",
                "evilweasel",
                "P@ssword",
                "192.168.178.1",
                "It hurts when IP"));
        }
        [RelayCommand]
        public void AddEntry()
        {
            PasswordEntries.Add(new PasswordEntry(
                "test",
                "evilweasel",
                "P@ssword"
            ));
        }
    }
}
