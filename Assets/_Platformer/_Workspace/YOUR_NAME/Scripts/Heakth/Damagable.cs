using System;

[Serializable]
public struct DamageInfo
{
    public float damage;
}

public interface IDamagable
{
    public void TakeDamage(DamageInfo damageInfo);
}
