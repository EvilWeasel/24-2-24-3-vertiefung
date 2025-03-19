using maui_cerberus_pass.ViewModels;

namespace maui_cerberus_pass.Views;

[QueryProperty(nameof(Entry), "Entry")]
public partial class DetailsPage : ContentPage
{
	public DetailsPage(DetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}