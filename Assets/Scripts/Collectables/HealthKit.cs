using UnityEngine;

public class HealthKit : Collectable
{
    [SerializeField] private float _healingAmount = 30;

    public float HealingAmount => _healingAmount;

    private HealthKit()
    {
        this.TypeCollectable = TypeCollectable.HealthKit;
    }

    public override void Collect()
    {
        base.Collect();
    }
}