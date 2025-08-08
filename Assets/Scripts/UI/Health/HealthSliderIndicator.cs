using UnityEngine;
using UnityEngine.UI;

public class HealthSliderIndicator : HealthIndicatorBase
{
    [SerializeField] private Slider _slider;

    protected override void Display()
    {
        _slider.value = Health.Value / Health.MaxValue;
    }
}
