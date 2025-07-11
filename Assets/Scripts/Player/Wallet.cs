using System;
using UnityEngine;


class Wallet : MonoBehaviour
{
    [SerializeField] private int _countCoin = 0;

    public void IncreaseCoin()
    {
        _countCoin++;
    }
}