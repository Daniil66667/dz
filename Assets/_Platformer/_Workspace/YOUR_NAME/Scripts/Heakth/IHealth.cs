public delegate void OnDamage(IHealth health, DamageInfo damageInfo);
public interface IHealth
{
    public float Max { get; }
    public float Ratio { get; }
    public bool IsAlive { get; }

    public event OnDamage onDamage;
    public event OnDamage onHeal;
    public event OnDamage onDeath;

    public bool CanBeDamaged();
    public float TakeDamage(DamageInfo damageInfo);

    public bool CanBeHealed();
    public float TakeHeal(DamageInfo damageInfo);
}
