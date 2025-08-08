using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Attacker _attacker;
    [SerializeField] private AttackArea _attackArea;
    [SerializeField] private PathGuide _pathGuide;
    [SerializeField] private Path _path;
    [SerializeField] private DirectionalMover _directionMover;
    [SerializeField] private TargetMover _targetMover;
    [SerializeField] private DetectionRadius _detectRadius;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _detectRadius.Detect += Follow;

        _health.Ended += Die;
    }

    private void OnDisable()
    {
        _detectRadius.Detect -= Follow;

        _health.Ended -= Die;
    }

    private void Start()
    {
        _targetMover.enabled = false;
        _pathGuide.SetPath(_path);
    }

    private void Update()
    {
        if (_directionMover.enabled)
        {
            Vector2 direction = _pathGuide.GetDirection(transform.position);
            _directionMover.SetDirection(direction);
        }
        else if (_targetMover.enabled)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (_attackArea.EntityCount > 0)
            _attacker.Attack();

    }

    private void Follow(Player target)
    {
        _directionMover.enabled = false;

        _targetMover.SetTarget(target.transform);
        _targetMover.enabled = true;
    }
    
    private void Die()
    {
        gameObject.SetActive(false);
    }
}