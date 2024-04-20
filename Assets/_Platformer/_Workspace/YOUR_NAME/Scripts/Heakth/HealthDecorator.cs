public abstract class HealthDecorator : IHealth
{
    private IHealth _health;

    public virtual float Max => _health.Max;

    public virtual float Ratio => _health.Ratio;

    public virtual bool IsAlive => _health.IsAlive;

    public virtual event OnDamage onDamage
    {
        add
        {
            _health.onDamage += value;
        }

        remove
        {
            _health.onDamage -= value;
        }
    }

    public virtual event OnDamage onHeal
    {
        add
        {
            _health.onHeal += value;
        }

        remove
        {
            _health.onHeal -= value;
        }
    }

    public virtual event OnDamage onDeath
    {
        add
        {
            _health.onDeath += value;
        }

        remove
        {
            _health.onDeath -= value;
        }
    }

    public virtual bool CanBeDamaged()
    {
        return _health.CanBeDamaged();
    }

    public virtual bool CanBeHealed()
    {
        return _health.CanBeHealed();
    }

    public virtual float TakeDamage(DamageInfo damageInfo)
    {
        return _health.TakeDamage(damageInfo);
    }

    public virtual float TakeHeal(DamageInfo damageInfo)
    {
        return _health.TakeHeal(damageInfo);
    }

    public virtual IHealth Assign(IHealth health)
    {
        _health = health;
        return this;
    }
}
