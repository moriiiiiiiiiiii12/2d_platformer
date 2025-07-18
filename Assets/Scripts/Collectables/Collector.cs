using System;
using UnityEngine;


public class Collector : MonoBehaviour
{
    public event Action<ICollectable> CoinCollected;
    public event Action<ICollectable> HealthKitCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ICollectable collectable))
        {
            collectable.Collect();

            switch (collectable.TypeCollectable)
            {
                case TypeCollectable.Coin:
                    CoinCollected?.Invoke(collectable);
                    break;

                case TypeCollectable.HealthKit:
                    HealthKitCollected?.Invoke(collectable);
                    break;
            }
        }
    }
}
