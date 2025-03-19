using maui_mvvm.Model;
using maui_mvvm.ViewModel;

namespace maui_mvvm.View;
public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        // MyPerson = new Person("Alexander", "Galagan");
        InitializeComponent(); // hier wird data-binding gesetzt
        // MyPerson = new Person("Alexander", "Galagan");
        // BindingContext = new MainViewModel();
        BindingContext = viewModel;
    }
}
