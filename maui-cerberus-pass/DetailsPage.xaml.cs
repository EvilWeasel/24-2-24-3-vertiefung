using System.Threading.Tasks;

namespace maui_cerberus_pass;

[QueryProperty(nameof(Entry), "Entry")]
public partial class DetailsPage : ContentPage
{
	private PasswordEntry entry;
	public PasswordEntry Entry
	{
		get => entry;
		set
		{
			entry = value;
			OnPropertyChanged();
		}
	}
		// = new PasswordEntry("test", "test", "test");
	public DetailsPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("//MainPage");
    }
}