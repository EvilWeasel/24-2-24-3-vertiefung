using polymorphism_logging;

Console.WriteLine("Programm start");

// instanziiere eine Bestellung
var bestellung1 = new Bestellung(
  0,
  "Schwarzenegger",
  "Proteinpulver PowerMax1000",
  42,
  69.69m
);
var bestellung2 = new Bestellung(
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
