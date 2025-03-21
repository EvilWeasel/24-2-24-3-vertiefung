using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using maui_cerberus_pass.Services;
using password_manager_toolkit;

namespace maui_cerberus_pass.ViewModels;

public partial class AddEntryViewModel : BaseViewModel
{
    [ObservableProperty]
    PasswordEntry entry;

    [ObservableProperty]
    bool isPasswordHidden = true;

    PasswordManager manager;
    PromptService prompter;
    public AddEntryViewModel(PasswordManager manager, PromptService promptService)
    {
        entry = new PasswordEntry(
            string.Empty,string.Empty,string.Empty);
        this.manager = manager;
        this.prompter = promptService;
    }
    [RelayCommand]
    public async Task AddEntry()
    {
        var masterpass = await prompter.GetVerifiedMasterPass(UIAction.Create);
        if (string.IsNullOrEmpty(masterpass))
            return;
        manager.CreateEntry(
            masterpass,
            Entry.Title,
            Entry.Login,
            Entry.Password,
            Entry.Website,
            Entry.Note);
        await Shell.Current.GoToAsync("..?Refresh=True");
    }
    [RelayCommand]
    public void TogglePasswordVisible()
        => IsPasswordHidden = !IsPasswordHidden;
}
