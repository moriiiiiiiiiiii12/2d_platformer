using UnityEngine;


[RequireComponent(typeof(Collider2D))]
class Wallet : MonoBehaviour
{
    [SerializeField] private int _countCoin = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            coin.CollectCoin();
            IncreaseCoin();
        }
    }

    private void IncreaseCoin()
    {
        _countCoin++;
    }
}