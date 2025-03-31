using BuchverkaufBinder.Model;
using BuchverkaufBinder.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BuchverkaufBinder.ViewModel;

[QueryProperty(nameof(Book), "Book")]
public partial class BookDetailsViewModel : BaseViewModel
{
    [ObservableProperty]
    Book? book;
    BookService bookService;
    public BookDetailsViewModel(BookService bookService)
    {
        Title = "Book Details";
        this.bookService = bookService;
    }

    [RelayCommand]
    public async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
    [RelayCommand]
    public void SaveBook()
    {
        bookService.AddBook(Book);
    }
    public void DeleteBook()
    {

    }
}
