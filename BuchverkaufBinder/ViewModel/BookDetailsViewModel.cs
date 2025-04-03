using System.Net.Http.Headers;
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
    HttpClient httpClient;
    public BookDetailsViewModel(BookService bookService, HttpClient httpClient)
    {
        Book = new();
        Title = "Book Details";
        this.bookService = bookService;
        this.httpClient = httpClient;
    }

    [RelayCommand]
    public async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
    [RelayCommand]
    public async Task SaveBook()
    {
        Book.ValidateBook();
        if (Book.HasErrors)
        {
            var message = string.Join(
                Environment.NewLine,
                Book.GetErrors().Select(e => e.ErrorMessage));
            await Shell.Current.DisplayAlert("Error❗", message, "Okay 🙀");
            return;
        }
        // check if cover exists
        var response = await httpClient.GetAsync($"https://covers.openlibrary.org/b/ISBN/{Book.ISBN}-L.jpg");
        if (response?.Content?.Headers?.ContentType?.MediaType?.Contains("image") ?? false)
            Book.ImageSourceUrl = $"https://covers.openlibrary.org/b/ISBN/{Book.ISBN}-L.jpg";
        else
            Book.ImageSourceUrl = "covernotavailable.png";

        if (IsNew)
            await bookService.AddBook(Book);
        else
            await bookService.UpdateBook(Book);
        await Shell.Current.GoToAsync(
            "..?Refresh=true");
    }
    [RelayCommand]
    public async Task DeleteBook()
    {
        if (!IsNew)
            await bookService.DeleteBook(Book.Id);
        await Shell.Current.GoToAsync(
    "..?Refresh=true");
    }
}
