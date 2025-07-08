using System;
using UnityEngine;


class CoinCollector : MonoBehaviour
{
    [SerializeField] private int _countCoin = 0;

    public int CountCoin => _countCoin;

    public event Action CoinChange;

    public void IncreaseCoin()
    {
        _countCoin++;
    }
}