using System;
using UnityEngine;

[Serializable]
public class DamageCapDecorator : HealthDecorator
{
    [SerializeField] private float maxDamage;

    public override float TakeDamage(DamageInfo damageInfo)
    {
        damageInfo.damage = Mathf.Min(damageInfo.damage, maxDamage);
        return base.TakeDamage(damageInfo);
    }
}