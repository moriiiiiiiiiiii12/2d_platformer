using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Wallet coinCollector))
        {
            coinCollector.IncreaseCoin();

            Destroy(gameObject); 
        }
    }
}
