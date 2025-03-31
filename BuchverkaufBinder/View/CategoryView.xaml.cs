using BuchverkaufBinder.ViewModel;

namespace BuchverkaufBinder.View;

public partial class CategoryView : ContentPage
{
	public CategoryView(CategoryViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
}