using UnityEngine;


class Wallet : MonoBehaviour
{
    [SerializeField] Collector _collector;
    [SerializeField] private int _countCoin = 0;

    private void OnEnable()
    {
        _collector.CoinCollected += IncreaseCoin;
    }

    private void OnDisable()
    {
        _collector.CoinCollected -= IncreaseCoin;
    }

    private void IncreaseCoin()
    {
        _countCoin++;
    }
}