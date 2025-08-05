using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class HealthTextIndicator : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _textMeshPro;

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
        _textMeshPro.text = $"{math.round(_health.Value)}/{_health.MaxValue}";
    }
}
