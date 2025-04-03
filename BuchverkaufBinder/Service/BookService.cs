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

    public async Task UpdateBook(Book changedBook)
    {
        var bookToUpdate
            = context.Books.Find(changedBook.Id);
        bookToUpdate.Title = changedBook.Title;
        bookToUpdate.Price = changedBook.Price;
        bookToUpdate.Author = changedBook.Author;
        bookToUpdate.ISBN = changedBook.ISBN;
        bookToUpdate.Category = changedBook.Category;
        bookToUpdate.ImageSourceUrl = changedBook.ImageSourceUrl;
        await context.SaveChangesAsync();
    }

    public async Task DeleteBook(int id)
    {
        // context.Books.Remove(new Book(){ Id = id});
        var bookToRemove = context.Books.Find(id);
        context.Books.Remove(bookToRemove);
        await context.SaveChangesAsync();
    }
}
