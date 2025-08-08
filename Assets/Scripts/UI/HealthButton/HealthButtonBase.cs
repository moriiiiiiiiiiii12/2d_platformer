using UnityEngine;
using UnityEngine.UI;

public abstract class HealthButtonBase : MonoBehaviour
{
    [SerializeField] protected Button _button;
    [SerializeField] protected Health _targetHealth;
    [SerializeField] protected float _amount = 10f;

    protected virtual void OnEnable()
    {
        if (_button != null)
            _button.onClick.AddListener(OnButtonClicked);
    }

    protected virtual void OnDisable()
    {
        if (_button != null)
            _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        if (_targetHealth == null) 
            return;
        
        Apply(_amount);
    }

    protected abstract void Apply(float amount);
}
