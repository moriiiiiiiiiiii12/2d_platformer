using System;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField] private LayerMask _layer;  

    private List<Health> _entity = new List<Health>();

    public int EntityCount => _entity.Count;

    public event Action HasEntity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int collisionLayerMask = 1 << collision.gameObject.layer;

        if (collision.TryGetComponent(out Health health) && collisionLayerMask == _layer.value)
        {
            _entity.Add(health);
            HasEntity?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        int collisionLayerMask = 1 << collision.gameObject.layer;

        if (collision.TryGetComponent(out Health health) && collisionLayerMask == _layer.value)
        {
            _entity.Remove(health);
        }
    }

    public Health GetEntity()
    {
        if (_entity.Count > 0)
            return _entity[0];

        return null;
    }
}
