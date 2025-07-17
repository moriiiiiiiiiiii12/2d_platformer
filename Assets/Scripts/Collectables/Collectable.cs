using System;
using UnityEngine;


public class Collectable : MonoBehaviour, ICollectable
{
    public TypeCollectable TypeCollectable { get; protected set; }

    public event Action<Collectable> OnCollected;

    public virtual void Collect() => OnCollected?.Invoke(this);
}