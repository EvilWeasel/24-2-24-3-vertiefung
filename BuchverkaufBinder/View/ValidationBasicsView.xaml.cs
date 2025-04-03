using BuchverkaufBinder.ViewModel;

namespace BuchverkaufBinder.View;

public partial class ValidationBasicsView : ContentPage
{
	public ValidationBasicsView(ValidationBasicsViewModel viewmodel)
	{
		Title = "Validation Basics";
		InitializeComponent();
		BindingContext = viewmodel;
	}
}