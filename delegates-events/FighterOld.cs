namespace delegates_events;
class FighterOld
{
    public string Name { get; }
    private int health;
    private Random rng = new Random();
    public bool IsAlive { get => health > 0; }

    // Events
    // Event für Angriffe
    public delegate void AttackHandler(string attacker,
        string defender,
        int damage);
    public event AttackHandler OnAttack;
    // Event für kritische Treffer
    public delegate void CriticalHitHandler(
        string attacker,
        int damage);
    public event CriticalHitHandler OnCriticalHit;
    // Event für Niederlage
    public delegate void DefeatedHandler(string looser);
    public event DefeatedHandler OnDefeated;

    public FighterOld(string name)
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
            OnCriticalHit(Name, damage);
        }
        // OnAttackEvent
        OnAttack(Name, opponent.Name, damage);

        opponent.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 0;
            // OnDefeatedEvent
            OnDefeated(Name);
        }
    }
}
