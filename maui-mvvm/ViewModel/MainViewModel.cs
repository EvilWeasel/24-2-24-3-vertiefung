using System.ComponentModel;
using System.Runtime.CompilerServices;
using maui_mvvm.Model;

namespace maui_mvvm.ViewModel;
public class MainViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnProptertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    public List<Person> People = new List<Person>();
    public Person MyPerson { get; set; }
       = new Person("Tobi", "Wehrle");
    private string testViewModel = string.Empty;
    public string TestViewModel
    {
        get => testViewModel;
        set
        {
            testViewModel = value;
            OnProptertyChanged();
        }
    }

    public void Button_Clicked(object sender, EventArgs e)
    {
        People.Add(
            new Person(MyPerson.FirstName, MyPerson.LastName));
        MyPerson.FirstName = string.Empty;
        MyPerson.LastName = string.Empty;
    }
}
