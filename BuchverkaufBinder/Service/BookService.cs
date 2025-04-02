using BuchverkaufBinder.Model;

namespace BuchverkaufBinder.Service;

public class BookService
{
    private List<Book> books;
    public BookService()
    {
        books = new()
        {
            new Book() { Id = 0, Title = "Der Herr der Ringe", Author = "J.R.R. Tolkien", ISBN = "9783608963762", Category = "Fantasy", Price = 19.99m },
            new Book() { Id = 1, Title = "Harry Potter und der Stein der Weisen", Author = "J.K. Rowling", ISBN = "9783551551672", Category = "Fantasy", Price = 12.99m },
            new Book() { Id = 2, Title = "Das Lied von Eis und Feuer", Author = "George R.R. Martin", ISBN = "9783442267747", Category = "Fantasy", Price = 15.99m },
            new Book() { Id = 3, Title = "Der Hobbit", Author = "J.R.R. Tolkien", ISBN = "9783608961928", Category = "Fantasy", Price = 14.99m },
            new Book() { Id = 4, Title = "Die Chroniken von Narnia", Author = "C.S. Lewis", ISBN = "9783800050141", Category = "Fantasy", Price = 9.99m },

            new Book() { Id = 5, Title = "Sapiens: A Brief History of Humankind", Author = "Yuval Noah Harari", ISBN = "9780062316097", Category = "Non-Fiction", Price = 18.99m },
            new Book() { Id = 6, Title = "Homo Deus: A Brief History of Tomorrow", Author = "Yuval Noah Harari", ISBN = "9780062464316", Category = "Non-Fiction", Price = 17.99m },
            new Book() { Id = 7, Title = "Eine kurze Geschichte der Menschheit", Author = "Yuval Noah Harari", ISBN = "9783406678593", Category = "Non-Fiction", Price = 20.99m },
            new Book() { Id = 8, Title = "Thinking, Fast and Slow", Author = "Daniel Kahneman", ISBN = "9780374533557", Category = "Non-Fiction", Price = 16.99m },
            new Book() { Id = 9, Title = "Educated", Author = "Tara Westover", ISBN = "9780399590504", Category = "Non-Fiction", Price = 13.99m },

            new Book() { Id = 10, Title = "Clean Code: A Handbook of Agile Software Craftsmanship", Author = "Robert C. Martin", ISBN = "9780132350884", Category = "Technology", Price = 29.99m },
            new Book() { Id = 11, Title = "The Pragmatic Programmer", Author = "Andrew Hunt, David Thomas", ISBN = "9780135957059", Category = "Technology", Price = 27.99m },
            new Book() { Id = 12, Title = "Design Patterns: Elements of Reusable Object-Oriented Software", Author = "Erich Gamma et al.", ISBN = "9780201633610", Category = "Technology", Price = 35.99m },
            new Book() { Id = 13, Title = "Introduction to Algorithms", Author = "Thomas H. Cormen et al.", ISBN = "9780262033848", Category = "Technology", Price = 49.99m },
            new Book() { Id = 14, Title = "You Don't Know JS: Scope & Closures", Author = "Kyle Simpson", ISBN = "9781449335588", Category = "Technology", Price = 24.99m },

            new Book() { Id = 15, Title = "To Kill a Mockingbird", Author = "Harper Lee", ISBN = "9780061120084", Category = "Classic", Price = 10.99m },
            new Book() { Id = 16, Title = "1984", Author = "George Orwell", ISBN = "9780451524935", Category = "Classic", Price = 9.99m },
            new Book() { Id = 17, Title = "Pride and Prejudice", Author = "Jane Austen", ISBN = "9780141439518", Category = "Classic", Price = 8.99m },
            new Book() { Id = 18, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", ISBN = "9780743273565", Category = "Classic", Price = 10.99m },
            new Book() { Id = 19, Title = "Moby Dick", Author = "Herman Melville", ISBN = "9781503280786", Category = "Classic", Price = 11.99m }
        };
    }

    public List<Book> GetBooks() => books;

    public void AddBook(Book newBook)
    {
        newBook.Id = books.Count;
        books.Add(newBook);
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
