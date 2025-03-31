using BuchverkaufBinder.ViewModel;

namespace BuchverkaufBinder.View;

public partial class BookDetailsView : ContentPage
{
	public BookDetailsView(BookDetailsViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
}