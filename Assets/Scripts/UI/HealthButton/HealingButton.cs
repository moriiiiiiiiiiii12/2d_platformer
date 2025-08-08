using UnityEngine;

public class HealingButton : HealthButtonBase
{
    protected override void Apply(float amount)
    {
        _targetHealth.Increase(amount);
    }
}
