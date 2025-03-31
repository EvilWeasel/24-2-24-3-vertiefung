using CommunityToolkit.Mvvm.Input;

namespace BuchverkaufBinder.ViewModel;

public partial class BookDetailsViewModel : BaseViewModel
{
    [RelayCommand]
    public async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}
