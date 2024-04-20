using System;
using System.Collections;
using UnityEngine;

[Serializable]
public struct AttackInfo
{
    [SerializeField, Min(0f)] private float range;
    [SerializeField, Min(0f)] private float preparatoion;
    [SerializeField, Min(0f)] private float execution;
    [SerializeField, Min(0f)] private float cooldown;

    public float Range => range;
    public float Range1 => range;
    public float Preparatoion => preparatoion;
    public float Execution => execution;
    public float Cooldown => cooldown;
}

public class MeleeWeapon : MonoBehaviour
{
    public enum WeaponState
    {
        Idle,
        Preparation,
        Execution,
        Cooldown
    }
    [Header("Melee")]
    [SerializeField] private MeleeConfig config;

    [Header("Attack")]
    [SerializeField] private Transform attackCenter;
    [SerializeField] private LayerMask layers;

    private bool _pendingAttack;
    private int _comboCounter;

    private WeaponState _state;

   public int ComboCounter
    {
        get => _comboCounter;
        private set => _comboCounter = value % config.Attacks.Length;
    }

    public bool IsAttacking => _state > WeaponState.Idle;

    public delegate void OnAttack(int counter);
    public event OnAttack onAttack;

    public void Attack()
    {
        if (_pendingAttack) return;
        _pendingAttack = true;

        if (IsAttacking) return;

        StartCoroutine(PerformAttack());
}

    private IEnumerator PerformAttack()
    {
        if (IsAttacking) yield break;

        var attack = config.Attacks[ComboCounter];

        onAttack?.Invoke(ComboCounter);
        _state = WeaponState.Preparation;
        yield return new WaitForSeconds(attack.Preparatoion);

        _pendingAttack = false;
        _state = WeaponState.Execution;
        StartCoroutine(DealDamage(attack.Range));

        yield return new WaitForSeconds(attack.Execution);

        _state = WeaponState.Cooldown;
        yield return new WaitForSeconds(attack.Cooldown);

        ComboCounter++;
        _state = WeaponState.Idle;

        if (_pendingAttack)
        {
            StartCoroutine(PerformAttack());
            yield break;
        }

        yield return new WaitForSeconds(config.ComboCooldown);

        if (!IsAttacking) ComboCounter = 0;
    }

    private IEnumerator DealDamage(float range)
    {
        while (_state == WeaponState.Execution)
        {
            var results = Physics2D.CircleCastAll(attackCenter.position, range, transform.right, 0f, layers);

            foreach (var result in results)
            {
                var damageable = result.collider.GetComponent<IDamagable>();
                damageable?.TakeDamage(config.Damage);
            }

            yield return new WaitForFixedUpdate();
     }
   } 
}
