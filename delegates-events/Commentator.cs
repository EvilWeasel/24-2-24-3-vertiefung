namespace delegates_events;
class Commentator
{
    public Commentator(Fighter fighterA, Fighter fighterB)
    {
        Subscribe(fighterA);
        Subscribe(fighterB);
    }

    private void Subscribe(Fighter fighter)
    {
        fighter.OnAttack += OnAttack;
        fighter.OnCriticalHit += OnCriticalHit;
        fighter.OnDefeated += OnDefeated;
    }

    public void OnAttack(
        string attacker,
        string defender,
        int damage)
    => Console.WriteLine(
        $"👊 {attacker} trifft {defender} für {damage} Schaden!");

    public void OnCriticalHit(
        string attacker,
        int damage)
        => Console.WriteLine(
            $"💥 KRITISCHER TREFFER!!! Der nächste Angriff von {attacker} verursacht {damage} Schaden!");

    public void OnDefeated(string loser)
        => Console.WriteLine($"💀 {loser} geht zu Boden!");
}