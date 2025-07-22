using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private AttackArea _attackArea;
    [SerializeField] private float _minAttackValue;
    [SerializeField] private float _maxAttackValue;
    [SerializeField] private float _cooldown;

    private bool _canAttack = true;

    public void Attack()
    {
        if (_canAttack == false)
            return; 

        float attackValue = Random.Range(_minAttackValue, _maxAttackValue);
        Health entity = _attackArea.GetEntity(); 

        if (entity != null)
        {
            entity.Decrease(attackValue);
        }

        StartCoroutine(WaitCooldown());
    }

    private IEnumerator WaitCooldown()
    {
        _canAttack = false;

        yield return new WaitForSeconds(_cooldown);

        _canAttack = true;
    }
}
