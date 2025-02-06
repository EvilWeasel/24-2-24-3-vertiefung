namespace cerberus_pass;

public class PasswordManager
{
  private List<PasswordEntry> vault;

  public PasswordManager()
  {
    // vault = new List<PasswordEntry>();
    // vault = new();
    // vault = [];
    vault = [];
  }

  public List<PasswordEntry> GetAll() => vault;

  public PasswordEntry CreateEntry(
    string title,
    string login,
    string password,
    string website = "",
    string note = "")
  {
    var newEntry = new PasswordEntry(
      title,
      login,
      password,
      website,
      note
    );
    vault.Add(newEntry);
    return newEntry;
  }
}
