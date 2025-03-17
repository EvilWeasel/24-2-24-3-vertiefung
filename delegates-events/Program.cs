using System.Text;
using delegates_events;
Console.OutputEncoding = Encoding.UTF8;
// 2 fighter initialisieren
var fighterA = new Fighter("Mike Tyson");
var fighterB = new Fighter("Bud Spencer");

// 1 commentator initialisieren
Commentator commentator = new(fighterA, fighterB);

// cage-fight simulation
while (fighterA.IsAlive && fighterB.IsAlive)
{
    fighterA.Attack(fighterB);
    if (fighterB.IsAlive)
        fighterB.Attack(fighterA);

    Thread.Sleep(500);
}

// fight over!
Console.WriteLine("🏆 Der Kampf ist vorbei!");