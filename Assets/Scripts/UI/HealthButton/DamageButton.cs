using UnityEngine;

public class DamageButton : HealthButtonBase
{
    protected override void Apply(float amount)
    {
        _targetHealth.Decrease(amount);
    }
}
