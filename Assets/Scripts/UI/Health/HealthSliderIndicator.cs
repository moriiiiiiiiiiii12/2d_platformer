using UnityEngine;

public class HealthSliderIndicator : HealthSliderIndicatorBase
{
    protected override void Display()
    {
        _slider.value = _health.Value / _health.MaxValue;
    }
}
