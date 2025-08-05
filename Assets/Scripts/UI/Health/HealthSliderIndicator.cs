using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class HealthSliderIndicator : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _health.TookDamage += Display;
        _health.Healed += Display;
    }

    private void OnDisable()
    {
        _health.TookDamage -= Display;
        _health.Healed -= Display;
    }

    private void Start()
    {
        Display();
    }

    private void Display()
    {
        _slider.value = _health.Value / _health.MaxValue;
    }
}
