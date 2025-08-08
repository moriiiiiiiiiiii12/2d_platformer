using System;
using TMPro;
using UnityEngine;

public class HealthTextIndicator : HealthIndicatorBase
{
    [SerializeField] private TextMeshProUGUI _text;

    protected override void Display()
    {
        _text.text = $"{Math.Round(Health.Value)}/{Health.MaxValue}";
    }
}
