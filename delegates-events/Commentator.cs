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
        object? sender, CriticalHitEventArgs e)
        => Console.WriteLine(
            $"💥 KRITISCHER TREFFER!!! Der nächste Angriff von {e.Attacker} verursacht {e.Damage} Schaden!");

    public void OnDefeated(object? sender, DefeatedEventArgs e)
        => Console.WriteLine($"💀 {e.Looser} geht zu Boden!");
}