using System.Collections.ObjectModel;
using BuchverkaufBinder.Model;
using BuchverkaufBinder.Service;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BuchverkaufBinder.ViewModel;

public partial class BookCollectionViewModel : BaseViewModel
{
    private BookService bookService;

    [ObservableProperty]
    ObservableCollection<Book> books;
    
    public BookCollectionViewModel(BookService bookService)
    {
        Title = "Book Collection";
        this.bookService = bookService;
        Books = new ObservableCollection<Book>(
            bookService.GetBooks());
    }
}
