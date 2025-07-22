using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public event Action CoinCollected;
    public event Action<float> HealthKitCollected;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ICollectable collectable;

        if (collider.TryGetComponent(out collectable) == false)
            return;

        switch (collectable)
        {
            case Coin coin:
                coin.Collect();
                CoinCollected?.Invoke();
                break;

            case HealthKit healthKit:
                healthKit.Collect();
                HealthKitCollected?.Invoke(healthKit.HealingAmount);
                break;
        }
    }
}
