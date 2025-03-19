using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using maui_mvvm.Helper;
using maui_mvvm.Model;
using maui_mvvm.Service;

namespace maui_mvvm.ViewModelManual;
public class MainViewModel : BaseViewModel
{
    public RelayCommand AddCommand => new RelayCommand(execute => AddPerson());
    public RelayCommand ShowAlertCommand => new RelayCommand(execute => ShowAlert());

    public ObservableCollection<Person> People;
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

    public MainViewModel(PeopleService peopleService)
    {
        People = peopleService.People;
    }

    public void AddPerson()
    {
        People.Add(
            new Person(MyPerson.FirstName, MyPerson.LastName));
        MyPerson.FirstName = string.Empty;
        MyPerson.LastName = string.Empty;
    }

    public void ShowAlert()
    {
        Shell.Current.DisplayAlert("ALARM", "Nice Job!", "Weiter im Text");
    }
}
