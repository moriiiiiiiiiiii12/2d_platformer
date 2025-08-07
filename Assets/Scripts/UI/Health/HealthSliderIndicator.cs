using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthSliderIndicator : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;
    [SerializeField] private bool _smooth = true;
    [SerializeField, Min(0f)] private float _speedChangeValue = 1f;

    private Coroutine _updateRoutine;
    private delegate void Display();
    private Display _display; 

    private void Awake()
    {
        if (_smooth)
        {
            _display = DisplaySmooth;
        }
        else
        {
            _display = DisplayInstant;
        }
    }

    private void OnEnable()
    {
        _health.TookDamage += OnHealthChanged;
        _health.Healed += OnHealthChanged;

        _display();
    }

    private void OnDisable()
    {
        _health.TookDamage -= OnHealthChanged;
        _health.Healed -= OnHealthChanged;

        if (_updateRoutine != null)
        {
            StopCoroutine(_updateRoutine);
        }
    }

    private void OnHealthChanged()
    {
        _display();
    }

    private void DisplaySmooth()
    {
        if (_updateRoutine != null)
        {
            StopCoroutine(_updateRoutine);
        }

        _updateRoutine = StartCoroutine(UpdateSmooth());
    }

    private IEnumerator UpdateSmooth()
    {
        float target = _health.Value / _health.MaxValue;

        while (Mathf.Approximately(_slider.value, target) == false)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, _speedChangeValue * Time.deltaTime);

            yield return null;
        }
    }

    private void DisplayInstant()
    {
        _slider.value = _health.Value / _health.MaxValue;
    }
}
