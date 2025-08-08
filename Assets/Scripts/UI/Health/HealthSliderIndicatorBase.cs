using UnityEngine;
using UnityEngine.UI;

public abstract class HealthSliderIndicatorBase : MonoBehaviour
{
    [SerializeField] protected Health _health;
    [SerializeField] protected Slider _slider;

    protected virtual void OnEnable()
    {
        _health.TookDamage += Display;
        _health.Healed += Display;
    }

    protected virtual void OnDisable()
    {
        _health.TookDamage -= Display;
        _health.Healed -= Display;
    }

    protected virtual void Start()
    {
        Display();
    }

    protected abstract void Display();
}
