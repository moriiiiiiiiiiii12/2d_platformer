using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private Collector _collector;
    [SerializeField] private float _minValue = 0;
    [SerializeField] private float _maxValue = 100;
    [SerializeField] private float _value = 100;

    public event Action TookDamage;

    private void OnEnable()
    {
        if (_collector != null)
            _collector.HealthKitCollected += Increase;
    }

    private void OnDisable()
    {
        if (_collector != null) 
            _collector.HealthKitCollected += Increase;
    }

    private void Increase(ICollectable collectable)
    {
        if (_value == _maxValue)
            return;

        if (collectable is HealthKit healthKit)
        {
            _value += healthKit.HealingAmount;

            if (_value > _maxValue)
                _value = _maxValue;
        }
    }

    public void Decrease(float value)
    {
        _value -= value;

        TookDamage?.Invoke();

        if (_value < _minValue)
            Die();
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}