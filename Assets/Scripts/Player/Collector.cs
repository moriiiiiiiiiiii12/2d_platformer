using System;
using UnityEngine;


public class Collector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    public event Action CoinCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            coin.CollectCoin();
            CoinCollected?.Invoke();
        }
    }
}