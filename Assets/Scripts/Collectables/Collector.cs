using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Health _health;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        ICollectable collectable;

        if (collider.TryGetComponent(out collectable) == false)
            return;

        switch (collectable)
        {
            case Coin coin:
                coin.Collect();
                _wallet.IncreaseCoin();
                break;

            case HealthKit healthKit:
                healthKit.Collect();
                _health.Increase(healthKit.HealingAmount);
                break;
        }
    }
}
