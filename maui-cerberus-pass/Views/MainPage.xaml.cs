using maui_cerberus_pass.ViewModels;

namespace maui_cerberus_pass.Views;
public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}