using password_manager_toolkit;

namespace maui_cerberus_pass.Services;

public class PromptService
{
    private readonly PasswordManager manager;
    public PromptService(PasswordManager manager)
    {
        this.manager = manager;
    }

    public async Task<string> GetVerifiedMasterPass(UIAction action)
    {
        var masterpass = await Shell.Current.DisplayPromptAsync(
    $"{action} Password?",
$"Enter your MasterPassword to confirm {action}.",
    "Confirm",
    "Stop",
    "P@ssword");
        if (!manager.VerifyMasterPassword(masterpass))
        {
            await Shell.Current.DisplayAlert(
                "Error",
                "Incorrect MasterPassword given!",
                "Try again");
            return string.Empty;
        }
        return masterpass;
    }
}

public enum UIAction
{
    Create,
    Update,
    Delete
}
