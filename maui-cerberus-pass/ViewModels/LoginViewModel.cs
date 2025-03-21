using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using maui_cerberus_pass.Views;
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
    bool isFirstStart = true;
    public LoginViewModel(PasswordManager manager)
    {
        this.manager = manager;
        Title = "Login";
        IsFirstStart = manager.IsFirstStart;
    }

    [RelayCommand]
    public async Task CheckMasterPass()
    {
        if (IsFirstStart)
        {
            if (InputMasterPassword == InputConfirmMasterPassword)
            {
                manager.SetupMasterPassword(InputMasterPassword);
                IsFirstStart = false;
                InputMasterPassword = string.Empty;
                InputConfirmMasterPassword = string.Empty;
                await Shell.Current.GoToAsync(nameof(MainPage));
            }
            else
            {
                await Shell.Current.DisplayAlert(
                    "Error",
                    "Passwords do not match!",
                    "Try again");
                return;
            }
        }
        else
        {
            if (manager.VerifyMasterPassword(InputMasterPassword))
            {
                InputMasterPassword = string.Empty;
                await Shell.Current.GoToAsync(nameof(MainPage));
            }
            else
            {
                await Shell.Current.DisplayAlert(
                    "Error",
                    "Incorrect MasterPassword given!",
                    "Try again");
                return;
            }
        }
    }
}
