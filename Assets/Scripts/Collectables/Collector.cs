using System;
using UnityEngine;


public class Collector : MonoBehaviour
{
    public event Action<ICollectable> CollectableCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ICollectable collectable))
        {
            collectable.Collect();
            CollectableCollected?.Invoke(collectable);
        }
    }
}
