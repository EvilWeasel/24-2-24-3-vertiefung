using System.Collections.ObjectModel;
using BuchverkaufBinder.Model;
using BuchverkaufBinder.Service;
using BuchverkaufBinder.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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

    [RelayCommand]
    public async Task GoToDetails(Book bookParam)
    {
        //await Shell.Current.GoToAsync("BookDetailsView");
        await Shell.Current.GoToAsync(nameof(BookDetailsView), true,
            new Dictionary<string, object>
            {
                // "Key", Value
                { "Book", new Book()
                    {
                        Title = bookParam.Title,
                        Author = bookParam.Author,
                        Category = bookParam.Category,
                        ISBN = bookParam.ISBN,
                        Price = bookParam.Price
                    }
                }
            });
    }
    [RelayCommand]
    public async Task GoToCreateDetails()
    {
        await Shell.Current.GoToAsync(nameof(BookDetailsView), true);
    }
}
