namespace delegates_events;

class CriticalHitEventArgs : EventArgs
{
    public string Attacker { get; }
    public int Damage { get; }
    public CriticalHitEventArgs(string attacker, int damage)
    {
        Attacker = attacker;
        Damage = damage;
    }
}
class DefeatedEventArgs : EventArgs
{
    public string Looser { get; }
    public DefeatedEventArgs(string looser)
    {
        Looser = looser;
    }
}

class Fighter
{
    public string Name { get; }
    private int health;
    private Random rng = new Random();
    public bool IsAlive { get => health > 0; }

    // Events
    // Event für Angriffe
    public event Action<string, string, int>? OnAttack;
    // Event für kritische Treffer
    public event EventHandler<CriticalHitEventArgs>? OnCriticalHit;
    // Event für Niederlage
    public event EventHandler<DefeatedEventArgs>? OnDefeated;

    public Fighter(string name)
    {
        Name = name;
        health = 100;
    }

    public void Attack(Fighter opponent)
    {
        var damage = rng.Next(5, 16);

        var isCritical = rng.Next(1, 21) == 1;

        if (isCritical)
        {
            damage *= 2;
            // OnCriticalEvent
            OnCriticalHit?.Invoke(this, new CriticalHitEventArgs(Name, damage));
            // OnCriticalHit(Name, damage);
        }
        // OnAttackEvent
        OnAttack?.Invoke(Name, opponent.Name, damage);
        //OnAttack(Name, opponent.Name, damage);

        opponent.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 0;
            // OnDefeatedEvent
            //OnDefeated(Name);
            OnDefeated?.Invoke(this, new DefeatedEventArgs(Name));
        }
    }
}
