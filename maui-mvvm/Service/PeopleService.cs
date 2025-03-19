using System.Collections.ObjectModel;
using maui_mvvm.Model;

namespace maui_mvvm.Service;

public class PeopleService
{
    public ObservableCollection<Person> People { get; set; } = new();
}
