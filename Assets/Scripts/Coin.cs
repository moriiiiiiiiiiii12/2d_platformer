using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Wallet coinCollector))
        {
            coinCollector.IncreaseCoin();

            gameObject.SetActive(false);
        }
    }
}
