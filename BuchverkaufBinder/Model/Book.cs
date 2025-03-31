namespace BuchverkaufBinder.Model;
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public string GetImageSourceUrlLarge
        => $"https://covers.openlibrary.org/b/ISBN/{ISBN}-L.jpg";
}
