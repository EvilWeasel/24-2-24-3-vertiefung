using System.Collections.ObjectModel;
using maui_mvvm.Model;
using maui_mvvm.Service;

namespace maui_mvvm.ViewModel;

public partial class PeopleViewModel : BaseViewModel
{
    public ObservableCollection<Person> People { get; set; }
    public PeopleViewModel(PeopleService peopleService)
    {
        People = peopleService.People;
    }
}
