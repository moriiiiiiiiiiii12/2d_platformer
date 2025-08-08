using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthSmoothSliderIndicator : HealthIndicatorBase
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _speedChangeValue = 100f;

    private Coroutine _animation;

    protected override void Display()
    {
        if (_animation != null)
            StopCoroutine(_animation);

        _animation = StartCoroutine(UpdateValue());
    }

    private IEnumerator UpdateValue()
    {
        float target = Health.Value / Health.MaxValue;

        while (Mathf.Approximately(_slider.value, target) == false)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, _speedChangeValue * Time.deltaTime);

            yield return null;
        }

        _animation = null;
    }
}
