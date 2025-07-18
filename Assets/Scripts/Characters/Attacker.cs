using UnityEditor;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _minAttackValue;
    [SerializeField] private float _maxAttackValue;
    [SerializeField] private float _radius;

    public void Attack()
    {
        float attackValue = Random.Range(_minAttackValue, _maxAttackValue);

        Health entity = GetEntity();

        if (entity != null)
            entity.Decrease(attackValue);
    }

    private Health GetEntity()
    {
        Collider2D[] entities = Physics2D.OverlapCircleAll(transform.position, _radius);

        foreach (Collider2D entity in entities)
        {
            if (entity.gameObject.TryGetComponent(out Health health))
                return health;
        }

        return null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}