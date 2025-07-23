using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private Collector _collector;
    [SerializeField] private float _minValue = 0;
    [SerializeField] private float _maxValue = 100;
    [SerializeField] private float _value = 100;

    public event Action TookDamage;
    public event Action HealthEnded;

    private void OnEnable()
    {
        if (_collector != null)
            _collector.HealthKitCollected += Increase;
    }

    private void OnDisable()
    {
        if (_collector != null)
            _collector.HealthKitCollected -= Increase;
    }

    private void Increase(float value)
    {
        if (_value == _maxValue)
            return;

        _value += value;

        if (_value > _maxValue)
            _value = _maxValue;
    }

    public void Decrease(float value)
    {
        _value -= value;

        TookDamage?.Invoke();

        if (_value < _minValue)
            HealthEnded?.Invoke();
    }
}
