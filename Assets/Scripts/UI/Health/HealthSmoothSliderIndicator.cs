using System.Collections;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class HealthSmoothSliderIndicator : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;

    [SerializeField] private float _speedChangeValue;

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
        StartCoroutine(UpdateValue());
    }

    private IEnumerator UpdateValue()
    {
        bool isChanges = true;

        while (isChanges)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _health.Value, _speedChangeValue * Time.deltaTime);

            if (_slider.value == _health.Value)
                isChanges = false;

            yield return null;
        }
    }
}
