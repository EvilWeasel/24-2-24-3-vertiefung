using polymorphism_logging;

Console.WriteLine("Programm start");

// Erstelle Liste mit Dateiloggern, um die Dateien zu erstellen
List<IFileLogger> fileLoggers = [];
fileLoggers.Add(new TextFileLogger("Kunde 2"));
fileLoggers.Add(new JSONFileLogger("Kunde 3"));
foreach (var log in fileLoggers)
{
    File.Create(log.FilePath).Dispose();
}



// instanziiere eine Bestellung
var logger1 = new JSONFileLogger("Schwarzenegger");
var bestellung1 = new Bestellung(
  logger1,
  0,
  "Schwarzenegger",
  "Proteinpulver PowerMax1000",
  42,
  69.69m
);
var logger2 = new ConsoleLogger("Ronni");
var bestellung2 = new Bestellung(
  logger2,
  1,
  "Ronni",
  "Kreatin",
  1024,
  6144.99m
);
// verarbeite bestellung
bestellung1.ProcessOrder();
bestellung2.ProcessOrder();
// liefere bestellung aus
bestellung1.ShipOrder();
bestellung2.ShipOrder();



Console.WriteLine("Programm ende");
