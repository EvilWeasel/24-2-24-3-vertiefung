using maui_cerberus_pass.ViewModels;
namespace maui_cerberus_pass.Views;

public partial class AddEntryPage : ContentPage
{
	public AddEntryPage(AddEntryViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
		Title = "New Password";
	}
}