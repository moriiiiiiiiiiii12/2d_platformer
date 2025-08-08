using System.Collections;
using UnityEngine;

public class HealthSmoothSliderIndicator : HealthSliderIndicatorBase
{
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
        while (Mathf.Approximately(_slider.value, _health.Value) == false)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _health.Value, _speedChangeValue * Time.deltaTime);

            yield return null;
        }
    }
}
