using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using maui_cerberus_pass.Services;
using password_manager_toolkit;

namespace maui_cerberus_pass.ViewModels;

[QueryProperty(nameof(Entry), "Entry")]
[QueryProperty(nameof(TitleToChange), "TitleToChange")]
public partial class DetailsViewModel : BaseViewModel
{
    public string TitleToChange { get; set; } = string.Empty;
    [ObservableProperty]
    PasswordEntry? entry;

    PasswordManager manager;
    PromptService prompter;
    [ObservableProperty]
    bool isPasswordHidden = true;
    public DetailsViewModel(PasswordManager manager, PromptService promptService)
    {
        this.manager = manager;
        this.prompter = promptService;
    }

    [RelayCommand]
    public async Task NavigateBack()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    public async Task UpdateEntry()
    {
        var masterpass = await prompter.GetVerifiedMasterPass(UIAction.Update);
        if (string.IsNullOrEmpty(masterpass))
            return;
        manager.UpdateEntry(
            masterpass,
            TitleToChange,
            Entry);
        await Shell.Current.GoToAsync("..?Refresh=True");
    }

    [RelayCommand]
    public async Task DeleteEntry()
    {
        var masterpass = await prompter.GetVerifiedMasterPass(UIAction.Delete);
        if (string.IsNullOrEmpty(masterpass))
            return;
        manager.DeleteEntry(
            masterpass,
            TitleToChange);
        await Shell.Current.GoToAsync("..?Refresh=True");
    }
    [RelayCommand]
    public void TogglePasswordVisible()
    => IsPasswordHidden = !IsPasswordHidden;
}
