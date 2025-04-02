using BuchverkaufBinder.Model;
using Microsoft.EntityFrameworkCore;

namespace BuchverkaufBinder.Data;
public class BookContext : DbContext
{
    // 1 DbSet per Table
    DbSet<Book> Books { get; set; }
    //DbSet<Authors> Authors { get; set; }

    public string DbPath { get; }

    public BookContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "binder.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
