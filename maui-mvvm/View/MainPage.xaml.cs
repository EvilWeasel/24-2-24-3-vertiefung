using maui_mvvm.Model;

namespace maui_mvvm.View;
public partial class MainPage : ContentPage
{
    public List<Person> People = new List<Person>();
    public Person MyPerson { get; set; } 
       = new Person("Tobi", "Wehrle");
    public MainPage()
    {
        // MyPerson = new Person("Alexander", "Galagan");
        InitializeComponent(); // hier wird data-binding gesetzt
        // MyPerson = new Person("Alexander", "Galagan");
        BindingContext = this;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        People.Add(
            new Person(MyPerson.FirstName, MyPerson.LastName));
        MyPerson.FirstName = string.Empty;
        MyPerson.LastName = string.Empty;
    }
}
