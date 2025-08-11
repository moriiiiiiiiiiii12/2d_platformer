using System;
using System.Collections;
using UnityEngine;

public class Vampirism : Ability
{
    [SerializeField] protected Health _health;
    [SerializeField] private float _radius;
    [SerializeField] private float _healthStealValue;
    [SerializeField] private LayerMask _enemyMask;

    public float Cooldown => _cooldown; 
    public float Duration => _duration;

    public event Action OnActivated;
    public event Action OnDeactivated;

    public override void Execute()
    {
        if (_coroutine == null)
        {
            OnActivated?.Invoke(); 
            _coroutine = StartCoroutine(ExecuteCoroutine());
        }
    }

    private IEnumerator ExecuteCoroutine()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);
        float elapsedTime = 0f;

        while (elapsedTime < _duration)
        {
            Health nearestHealth = GetNearestHealth();

            if (nearestHealth != null)
            {
                nearestHealth.Decrease(_healthStealValue);
                _health.Increase(_healthStealValue);
            }

            elapsedTime += _delay;

            yield return waitForSeconds;
        }

        OnDeactivated?.Invoke(); 

        StartCoroutine(WaitCooldown());
    }

    private Health GetNearestHealth()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius, _enemyMask);

        Health nearestHealth = null;
        float closestSqrDistance = Mathf.Infinity;

        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent(out Health health))
            {
                float sqrDistance = (collider.transform.position - transform.position).sqrMagnitude;

                if (sqrDistance < closestSqrDistance)
                {
                    closestSqrDistance = sqrDistance;
                    nearestHealth = health;
                }
            }
        }

        return nearestHealth;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}