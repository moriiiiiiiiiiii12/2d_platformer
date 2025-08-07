using UnityEngine;
using UnityEngine.UI;

public class HealthButton : MonoBehaviour
{
    public enum OperationType
    {
        Heal,
        Damage
    }

    [SerializeField] private Button _button;
    [SerializeField] private Health _targetHealth;
    [SerializeField] private OperationType _operation;
    [SerializeField] private float _value = 10f;

    private void OnEnable()
    {
        if (_operation == OperationType.Heal)
            _button.onClick.AddListener(DoHeal);
        else
            _button.onClick.AddListener(DoDamage);
    }

    private void OnDisable()
    {
        if (_operation == OperationType.Heal)
            _button.onClick.RemoveListener(DoHeal);
        else
            _button.onClick.RemoveListener(DoDamage);
    }

    private void DoHeal()
    {
        _targetHealth.Increase(_value);
    }

    private void DoDamage()
    {
        _targetHealth.Decrease(_value);
    }
}
