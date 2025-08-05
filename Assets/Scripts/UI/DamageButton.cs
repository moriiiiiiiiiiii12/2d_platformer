using UnityEngine;
using UnityEngine.UI;


public class DamageButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Health _targetHealth;
    [SerializeField] private float _damageValue;

    private void OnEnable()
    {
        _button.onClick.AddListener(Attack);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Attack);
    }

    private void Attack()
    {
        _targetHealth.Decrease(_damageValue);
    }
}