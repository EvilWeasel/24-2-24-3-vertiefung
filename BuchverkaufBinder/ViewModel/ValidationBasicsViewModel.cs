using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BuchverkaufBinder.ViewModel;
public partial class ValidationBasicsViewModel : BaseViewModel
{
    [ObservableProperty]
    [Required(ErrorMessage = "First name is not optional!")]
    [MinLength(2, ErrorMessage = "First name must be at least 2 characters long!")]
    string firstName = string.Empty;
    [ObservableProperty]
    string lastName = string.Empty;
    [ObservableProperty]
    [EmailAddress]
    string email = string.Empty;

    [RelayCommand]
    public async Task Submit()
    {
        ValidateAllProperties();
        if (HasErrors)
        {
            var message = string.Join(
                Environment.NewLine,
                GetErrors().Select(e => e.ErrorMessage));
            await Shell.Current.DisplayAlert("Error!", message, "Okay :c");
            return;
        }
        await Shell.Current.DisplayAlert(
            "Submit successfull",
            "Everything okay!",
            "Thank!");
    }
}
