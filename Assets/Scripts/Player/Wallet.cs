using UnityEngine;


class Wallet : MonoBehaviour
{
    [SerializeField] Collector _collector;
    [SerializeField] private int _countCoin = 0;

    private void OnEnable()
    {
        _collector.CollectableCollected += IncreaseCoin;
    }

    private void OnDisable()
    {
        _collector.CollectableCollected -= IncreaseCoin;
    }

    private void IncreaseCoin(ICollectable collectable)
    {
        if (collectable.TypeCollectable == TypeCollectable.Coin)
            _countCoin++;
    }
}