using System.Text.Json;

namespace password_manager_toolkit;

public class PasswordManager
{
    private List<PasswordEntry> vault;
    private string vaultFilePath = "vault.cerberus";
    private string masterPassFilePath = "masterpass.cerberus";
    public PasswordManager()
    {
        vault = [];
    }
    public PasswordManager(string baseFileDir)
    {
        this.vaultFilePath = Path.Join(baseFileDir, vaultFilePath);
        this.masterPassFilePath = Path.Join(baseFileDir, masterPassFilePath);
        vault = [];
    }
    public IEnumerable<PasswordEntry> GetAll() => vault;

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
    public PasswordEntry? UpdateEntry(
        string masterPass,
        string titleToChange,
        PasswordEntry newEntry)
    {
        var indexToUpdate = vault.FindIndex(
          x => x.Title == titleToChange);
        if (indexToUpdate == -1)
            return null;
        vault[indexToUpdate] = newEntry;
        SaveVault(masterPass);
        return vault[indexToUpdate];
    }

    // DeleteEntry
    public bool DeleteEntry(string masterPass, string titleToDelete)
    {
        var success = vault.RemoveAll(x => x.Title == titleToDelete) > 0;
        if (success)
            SaveVault(masterPass);
        return success;
    }
    private void SaveVault(string masterPass)
    {
        if (vault.Count < 1) return;
        var json = JsonSerializer.Serialize(vault);
        var encryptedJson = VaultEncryption.Encrypt(json, masterPass);
        File.WriteAllText(vaultFilePath, encryptedJson);
    }

    public void LoadVault(string masterPass)
    {
        var encryptedJson = File.Exists(vaultFilePath) ?
          File.ReadAllText(vaultFilePath) :
          "";
        if (String.IsNullOrEmpty(encryptedJson))
        {
            File.Create(vaultFilePath).Dispose();
            return;
        }
        // todo: masspass check

        var jsonPlain = VaultEncryption.Decrypt(encryptedJson, masterPass);
        vault = JsonSerializer.
          Deserialize<List<PasswordEntry>>(jsonPlain)
            ?? throw new FileLoadException("Malformed vault data! Could not parse contents!");
        // ?? => Null-Coalescing Operator
        // x = entweder ?? oder
        // ==> wenn "entweder" == null, dann ist x = "oder"
        // decrypt
    }

    public void SetupMasterPassword(string plainPassword)
    {
        if (File.Exists(masterPassFilePath)) return;
        var salt = String.Empty;
        var hashedPassword = VaultEncryption.HashPassword(plainPassword, out salt);

        File.WriteAllLines(masterPassFilePath,
            new[] { hashedPassword, salt });
    }
    public bool VerifyMasterPass(string plainPassword)
    {
        if (!File.Exists(masterPassFilePath)) return false;
        var storedMasterPass = File.ReadAllLines(masterPassFilePath);
        var storedHash = storedMasterPass[0];
        var storedSalt = storedMasterPass[1];
        return VaultEncryption.VerifyPassword(plainPassword, storedHash, storedSalt);
    }
    public bool IsFirstStart => !File.Exists(masterPassFilePath);
}
