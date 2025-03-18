using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace maui_propertychanged; // File-Scoped Namespace
public partial class MainPage : ContentPage
{
    public List<Person> People { get; set; } = [];
    public Person MyPerson { get; set; } = new Person(String.Empty, String.Empty);
    private string firstName;
    public string FirstName
    {
        get
        {
            Console.WriteLine(firstName);
            return firstName;
        }
        set
        {
            firstName = value;
            OnPropertyChanged(); // OnPropertyChanged("FirstName")
            // PropertyChanged.Invoke(this, newPropertyChangedEventArgs("FirstName"));
        }
    }
    public string LastName
    {
        get => lastName;
        set
        {
            lastName = value;
            OnPropertyChanged();
        }
    }
    private string privateField = String.Empty;
    private string lastName;


    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var newPerson = new Person(MyPerson.FirstName, MyPerson.LastName);
        People.Add(newPerson);
        MyPerson.FirstName = String.Empty;
        MyPerson.LastName = String.Empty;
    }
}

public class Person : INotifyPropertyChanged
{
    private string firstName;
    private string lastName;
    public string FirstName
    {
        get => firstName;
        set
        { 
            firstName = value;
            OnPropertyChanged();
        }
    }
    public string LastName
    {
        get => lastName;
        set
        {
            lastName = value;
            OnPropertyChanged();
            //PropertyChanged(this, new PropertyChangedEventArgs("LastName"));
        }
    }
    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    void OnPropertyChanged([CallerMemberName]string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
