using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using password_manager_toolkit;

namespace maui_cerberus_pass.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    private readonly PasswordManager manager;
    [ObservableProperty]
    string inputMasterPassword = string.Empty;
    [ObservableProperty]
    string inputConfirmMasterPassword = string.Empty;
    [ObservableProperty]
    bool firstStart = true;
    public LoginViewModel(PasswordManager manager)
    {
        this.manager = manager;
        Title = "Login";
    }

    [RelayCommand]
    public async Task CheckMasterPass()
    {
        /*
         if(IsFirstStart) {
            manager.SetupMasterPassword(InputMasterPassword)
            await Shell.Current.GoToAsync("MainPage")
        } else {
            if(manager.VerifyMasterPassword(InputMasterPassword)) {
                await Shell.Current.GoToAsync("MainPage")
        }
        }
         */
    }
}
