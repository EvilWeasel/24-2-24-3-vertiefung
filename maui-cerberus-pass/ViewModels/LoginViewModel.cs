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
    private bool isFirstStart = true;
    [ObservableProperty]
    private string errorMessage = string.Empty;

    public LoginViewModel(PasswordManager manager)
    {
        this.manager = manager;
        IsFirstStart = manager.IsFirstStart;
        Title = IsFirstStart ? "Vault Setup" : "Login";
    }


    [RelayCommand]
    public async Task CheckMasterPassword()
    {
        if (IsFirstStart)
        {
            if (InputMasterPassword == InputConfirmMasterPassword)
            {
                manager.SetupMasterPassword(InputMasterPassword);
                IsFirstStart = false;
                InputMasterPassword = string.Empty;
                InputConfirmMasterPassword = string.Empty;
                await Shell.Current.GoToAsync("MainPage");
            }
            else
            {
                ErrorMessage = "Passwords do not match!";
                await Shell.Current.DisplayAlert("Error", "Passwords do not match!", "OK");
                return;
            }
        }
        var isCorrect = manager.VerifyMasterPass(InputMasterPassword);
        if (isCorrect)
        {
            InputMasterPassword = string.Empty;
            InputConfirmMasterPassword = string.Empty;
            await Shell.Current.GoToAsync("MainPage");
        }
        else
        {
            ErrorMessage = "Wrong Password";
            await Shell.Current.DisplayAlert("Error", "Passwords do not match!", "OK");
            return;
        }
    }
}
