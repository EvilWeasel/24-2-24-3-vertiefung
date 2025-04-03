using System.Threading.Tasks;
using BuchverkaufBinder.Data;
using BuchverkaufBinder.Model;
using Microsoft.EntityFrameworkCore;

namespace BuchverkaufBinder.Service;

public class BookService
{
    private BookContext context;
    public BookService(BookContext context)
    {
        this.context = context;
    }

    public Task<List<Book>> GetBooks() => context.Books.ToListAsync();

    public async Task AddBook(Book newBook)
    {
        // newBook.Id = context.Books.Count();
        context.Books.Add(newBook);
        await context.SaveChangesAsync();
    }

    public void UpdateBook(Book changedBook)
    {
        var bookToUpdate
            = books.Find(b => b.Id == changedBook.Id);
        bookToUpdate.Title = changedBook.Title;
        bookToUpdate.Price = changedBook.Price;
        bookToUpdate.Author = changedBook.Author;
        bookToUpdate.ISBN = changedBook.ISBN;
        bookToUpdate.Category = changedBook.Category;
    }

    public void DeleteBook(int id)
    {
        var indexToRemove = books.FindIndex(b => b.Id == id);
        books.RemoveAt(indexToRemove);
    }
}
