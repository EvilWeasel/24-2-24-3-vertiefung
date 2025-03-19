namespace polymorphism_logging;

public class Bestellung
{
    public int Id { get; set; }
    public string Kunde { get; set; }
    public string Artikel { get; set; }
    public int Anzahl { get; set; }
    public decimal Preis { get; set; }
    public Logger Logger { get; set; }

    public Bestellung(
      Logger logger,
      int id,
      string kunde,
      string artikel,
      int anzahl,
      decimal preis
    )
    {
        Id = id;
        Kunde = kunde;
        Artikel = artikel;
        Anzahl = anzahl;
        Preis = preis;
        Logger = logger;
    }

    public void ProcessOrder()
    {
        var newPrefix = Logger switch
        {
            ConsoleLogger cl => "Console",
            TextFileLogger txtfl => "TextFileLogger",
            JSONFileLogger jsfl => "JsonFileLogger",
            _ => "Irgendwas anderes"
        };
        Logger.Originprefix = newPrefix;
        Logger.Log($"Processing OrderID {Id}"); // Log-Nachricht
        Thread.Sleep(500);
        Logger.Log("Processing..."); // Log-Nachricht
        Thread.Sleep(500);
        Console.WriteLine(
          $"{Id}: Kunde {Kunde} bestellt {Artikel} {Anzahl} mal für {Preis}€"
        ); // Was diese Methode eigentlich macht - Beispiel
        Thread.Sleep(500);
        Logger.Log($"Order {Id} was processed"); // Log-Nachricht
    }

    public void ShipOrder()
    {
        Logger.Originprefix = "ShipOrder -> " + Logger.Originprefix;
        Logger.Log($"Preparing to ship OrderID {Id}");
        Thread.Sleep(500);
        Logger.Log("Preparing..."); // Log-Nachricht
        Thread.Sleep(500);
        Console.WriteLine(
      $"Bestellung mit ID {Id} wurde versand."
        ); // Was diese Methode eigentlich macht - Beispiel
        Thread.Sleep(500);
        Logger.Log($"Order {Id} was shipped successfully"); // Log-Nachricht
    }

    // Für jede neue Methode eine eigene Logger Instanz
    // public void CreateInvoice(){}
}
