using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private Collider2D _attackArea;
    [SerializeField] private float _minAttackValue;
    [SerializeField] private float _maxAttackValue;
    [SerializeField] private float _cooldown;

    private bool _canAttack = true;

    public void Attack()
    {
        float attackValue = Random.Range(_minAttackValue, _maxAttackValue);

        Health entity = GetEntity();

        if (entity != null && _canAttack)
        {
            StartCoroutine(WaitCooldown());
            entity.Decrease(attackValue);
        }
    }

    private Health GetEntity()
    {
        Collider2D[] entities = Physics2D.OverlapCircleAll(transform.position, _radius);

        foreach (Collider2D entity in entities)
        {
            // if (entity.TryGetComponent(out Player player))
            if (entity.TryGetComponent(out Health health))
                return health;
        }

        return null;
    }

    private IEnumerator WaitCooldown()
    {
        _canAttack = false;

        yield return new WaitForSeconds(_cooldown);

        _canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}