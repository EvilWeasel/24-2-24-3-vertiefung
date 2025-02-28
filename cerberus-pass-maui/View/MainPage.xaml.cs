using cerberus_pass_maui.ViewModel;

namespace cerberus_pass_maui;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}
