namespace password_manager;
// PascalCase => BegriffstrennungenImmerErsterBuchstabeGroß
// => Properties, Funktionen / Methods, Classes, Namespaces, Enums
public class PasswordEntry
{
    public string Title { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Website { get; set; }
    public string Note { get; set; }

    public PasswordEntry(
      string title,
      string login,
      string password,
      string website = "",
      string note = "")
    {
        Title = title;
        Login = login;
        Password = password;
        Website = website;
        Note = note;
    }

    // ToString-Method
    // Wird z.B. von Console.WriteLine() implizit aufgerufen
    public override string ToString()
    {
        return $"{Title}\t{Website}\t{Login}";
    }
}
public class PasswordEntrySummary
{
    public string Title { get; set; }
    public string Login { get; set; }
    public string Website { get; set; }
    public string Note { get; set; }

    public PasswordEntrySummary(string title, string login, string website, string note)
    {
        Title = title;
        Login = login;
        Website = website;
        Note = note;
    }
    public override string ToString()
    {
        return $"{Title}\t{Website}\t{Login}\t${Note}";
    }
    // Explicit cast operator
    public static explicit operator PasswordEntrySummary(PasswordEntry entry)
        => new PasswordEntrySummary(entry.Title, entry.Login, entry.Website, entry.Note);
}
