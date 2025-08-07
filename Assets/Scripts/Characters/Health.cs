using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _minValue = 0;
    [SerializeField] private float _maxValue = 100;
    [SerializeField] private float _value = 100;

    public event Action TookDamage;
    public event Action Healed;
    public event Action HealthEnded;

    public float MinValue => _minValue; 
    public float MaxValue => _maxValue; 
    public float Value => _value;

    public void Increase(float value)
    {
        if (value <= 0)
            return;

        if (_value == _maxValue)
            return;

        _value += value;

        if (_value > _maxValue)
            _value = _maxValue;

        Healed?.Invoke();
    }

    public void Decrease(float value)
    {
        if (value <= 0)
            return;

        _value -= value;

        TookDamage?.Invoke();

        if (_value <= _minValue)
            HealthEnded?.Invoke();
    }
}
