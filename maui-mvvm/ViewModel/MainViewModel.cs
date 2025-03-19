using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using maui_mvvm.Helper;
using maui_mvvm.Model;

namespace maui_mvvm.ViewModel;
public partial class MainViewModel : BaseViewModel
{
    // public RelayCommand AddCommand => new RelayCommand(execute => AddPerson());
    // public RelayCommand ShowAlertCommand => new RelayCommand(execute => ShowAlert());

    public ObservableCollection<Person> People = Person.People;
    public Person MyPerson { get; set; }
       = new Person("Tobi", "Wehrle");
    [ObservableProperty]
    private string testViewModel = string.Empty;

    [RelayCommand]
    public void AddPerson()
    {
        People.Add(
            new Person(MyPerson.FirstName, MyPerson.LastName));
        MyPerson.FirstName = string.Empty;
        MyPerson.LastName = string.Empty;
    }

    [RelayCommand]
    public void ShowAlert()
    {
        Shell.Current.DisplayAlert("ALARM", "Nice Job!", "Weiter im Text");
    }
}
