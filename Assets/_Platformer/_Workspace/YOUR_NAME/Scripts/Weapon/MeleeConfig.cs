using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon/melee")]
public class MeleeConfig : ScriptableObject
{ 
    

    [Header("Weapon")]
    [SerializeField] private DamageInfo damage;
    
    [Header("Combo")]
    [SerializeField] private float comboCooldown;
    [SerializeField] private AttackInfo[] attacks;

    public DamageInfo Damage => damage;
    public float ComboCooldown => comboCooldown;
    public AttackInfo[] Attacks => attacks;
}
