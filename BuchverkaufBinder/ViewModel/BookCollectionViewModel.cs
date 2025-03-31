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
    public async Task GoToDetails()
    {
        //await Shell.Current.GoToAsync("BookDetailsView");
        await Shell.Current.GoToAsync(nameof(BookDetailsView));
    }
}
