namespace password_manager;

using System.Text.Json;

public class PasswordManager
{
  private List<PasswordEntry> vault = [];
  private const string vaultFilePath = "vault.cerberus";


  public IEnumerable<PasswordEntrySummary> GetAll() => vault.Select(e => (PasswordEntrySummary)e);

  public PasswordEntry? CreateEntry(
    string masterPass,
    string title,
    string login,
    string password,
    string website = "",
    string note = "")
  {
    if (vault.Any(x => x.Title == title))
    {
      return null;
    }
    var newEntry = new PasswordEntry(
      title,
      login,
      password,
      website,
      note
    );
    vault.Add(newEntry);
    SaveVault(masterPass);
    return newEntry;
  }

  // GetEntry
  public PasswordEntry? GetEntry(string title) =>
    vault.Find(x => x.Title == title);


  // UpdateEntry
  public PasswordEntry UpdateEntry(string masterPass, string titleToChange, PasswordEntry newEntry)
  {
    var indexToUpdate = vault.FindIndex(
      x => x.Title == titleToChange);
    vault[indexToUpdate] = newEntry;
    SaveVault(masterPass);
    return vault[indexToUpdate];

    // var entryToChange = vault.Find(x => x.Title == titleToChange);
    // entryToChange = newEntry;
  }

  // DeleteEntry
  public bool DeleteEntry(string masterPass, string titleToDelete)
  {
    var success = vault.RemoveAll(x => x.Title == titleToDelete) > 0;
    if (success)
      SaveVault(masterPass);
    return success;
  }

  /*
  public bool DeleteEntry(string titleToDelete)
  {
    var deleteCount = 0;
    for (int i = 0; i > vault.Count; i++)
    {
      if (vault[i].Title == titleToDelete)
      {
        vault.Remove(vault[i]);
        deleteCount++;
      }
    }
    if (deleteCount > 0)
    {
      return true;
    }
    else
    {
      return false;
    }
  } */

  // Save to File
  // Wer callt diese Funktion?
  private void SaveVault(string masterPass)
  {
    var json = JsonSerializer.Serialize(vault);
    var encryptedJson = VaultEncryption.Encrypt(json, masterPass);
    File.WriteAllText(vaultFilePath, encryptedJson);
  }

  // Load from File
  // Wer callt diese Funktion?
  public void LoadVault(string masterPass)
  {
    var fileContent = File.Exists(vaultFilePath) ?
      File.ReadAllText(vaultFilePath) :
      "";
    if (String.IsNullOrEmpty(fileContent))
    {
      File.Create(vaultFilePath).Dispose();
      return;
    }
    var encryptedJson = fileContent;
    var jsonPlain = VaultEncryption.Decrypt(encryptedJson, masterPass);
    vault = JsonSerializer.
      Deserialize<List<PasswordEntry>>(jsonPlain)
        ?? [];
    // ?? => Null-Coalescing Operator
    // x = entweder ?? oder
    // ==> wenn "entweder" == null, dann ist x = "oder"
    // decrypt
  }
}
