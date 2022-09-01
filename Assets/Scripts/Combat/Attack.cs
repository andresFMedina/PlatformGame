public class Attack
{
    private readonly int _damage;

    public Attack(int damage)
    {
        _damage = damage;
    }

    public int Damage { get { return _damage; } }
}
