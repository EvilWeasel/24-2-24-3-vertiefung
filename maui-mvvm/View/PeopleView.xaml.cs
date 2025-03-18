using maui_mvvm.ViewModel;

namespace maui_mvvm.View;

public partial class PeopleView : ContentPage
{
	public PeopleView()
	{
		InitializeComponent();
		BindingContext = new PeopleViewModel();
	}
}