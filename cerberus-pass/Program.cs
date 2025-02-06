// Main UI-Flow
using System.Text.RegularExpressions;
using cerberus_pass;

var pass1 = new PasswordEntry("Steam", "WaldmeisterSD", "P@ssword");

var pass2 = new PasswordEntry("Steam", "WaldmeisterSD", "P@ssword", "https://store.steampowered.com", "Mein cooler Steam-Account");

var pass3 = new PasswordEntry(
  "GOG",
  "Toaster",
  "P@ssword",
  "https://www.gog.com",
  "Der geilste Service um alte Videospiele zu erwerben!"
);

var manager = new PasswordManager();

Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine("Willkommen zu Cerberus-Pass!");
Console.ResetColor();

do
{
  Console.WriteLine("Wähle was du tun willst:");

  Console.WriteLine("""
  1. Passwort-Liste ausgeben
  2. Passwort mit ID ausgeben
  3. Neues Passwort erstellen
  4. Vorhandenes Passwort bearbeiten
  5. Passwort löschen
""");

  var userInput = Console.ReadLine();

  switch (userInput)
  {
    case "1":
      // Liste ausgeben
      var vault = manager.GetAll();
      Console.WriteLine(vault);
      break;
    case "2":
      // Passwort anhand ID ausgeben
      break;
    case "3":
      // Erstellen
      Console.WriteLine("Gebe einen Titel für den Eintrag an:");
      var title = Console.ReadLine();
      Console.WriteLine("Gebe einen Login für den Eintrag an:");
      var login = Console.ReadLine();
      Console.WriteLine("Gebe ein Passwort für den Eintrag an:");
      var password = Console.ReadLine();
      var newEntry = manager.CreateEntry(title, login, password);
      Console.WriteLine("Neuer Eintrag erfolgreich erstellt:");
      Console.WriteLine(newEntry); // Gibt Type aus;
      break;
    case "4":
      // Update
      break;
    case "5":
      // Delete
      break;
    default:
      // Fehler anzeigen -> Eingabe-Hint (1-5)
      // Eingabe wiederholen
      break;
  }
  Console.ReadKey();
  Console.Clear();
} while (true);
