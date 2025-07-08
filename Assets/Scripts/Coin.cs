using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CoinCollector coinCollector))
        {
            coinCollector.IncreaseCoin();

            Destroy(gameObject); 
        }
    }
}
