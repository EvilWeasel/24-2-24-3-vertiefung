using maui_cerberus_pass.ViewModels;

namespace maui_cerberus_pass.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
}