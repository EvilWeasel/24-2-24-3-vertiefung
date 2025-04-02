using System.Threading.Tasks;
using BuchverkaufBinder.Model;
using BuchverkaufBinder.Service;
using BuchverkaufBinder.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BuchverkaufBinder.ViewModel;

[QueryProperty(nameof(IsNew), "IsNew")]
[QueryProperty(nameof(Book), "Book")]
public partial class BookDetailsViewModel : BaseViewModel
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotNew))]
    bool isNew = false;
    public bool IsNotNew => !IsNew;
    [ObservableProperty]
    Book book;
    BookService bookService;
    public BookDetailsViewModel(BookService bookService)
    {
        Book = new();
        Title = "Book Details";
        this.bookService = bookService;
    }

    [RelayCommand]
    public async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
    [RelayCommand]
    public async Task SaveBook()
    {
        if (IsNew)
            bookService.AddBook(Book);
        else
            bookService.UpdateBook(Book);
        await Shell.Current.GoToAsync(
            "..?Refresh=true");
    }
    [RelayCommand]
    public async Task DeleteBook()
    {
        if (!IsNew)
            bookService.DeleteBook(Book.Id);
        await Shell.Current.GoToAsync(
    "..?Refresh=true");
    }
}
