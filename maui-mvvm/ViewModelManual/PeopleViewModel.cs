using System.Collections.ObjectModel;
using maui_mvvm.Model;

namespace maui_mvvm.ViewModelManual;

public class PeopleViewModel : BaseViewModel
{
    public ObservableCollection<Person> People { get; set; } = Person.People;
}
