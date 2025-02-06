// Main UI-Flow
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

Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine("Willkommen zu Cerberus-Pass!");
Console.ResetColor();

Console.WriteLine("Wähle was du tun willst:");

Console.WriteLine("""
  1. Passwort-Liste ausgeben
  2. Passwort mit ID ausgeben
  3. Neues Passwort erstellen
  4. Vorhandenes Passwort bearbeiten
  5. Passwort löschen
""");
