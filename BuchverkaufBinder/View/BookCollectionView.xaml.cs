using BuchverkaufBinder.ViewModel;

namespace BuchverkaufBinder.View;

public partial class BookCollectionView : ContentPage
{
	public BookCollectionView(BookCollectionViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
}