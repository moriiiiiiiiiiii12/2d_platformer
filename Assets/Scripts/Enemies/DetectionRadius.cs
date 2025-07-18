using System;
using UnityEngine;


public class DetectionRadius : MonoBehaviour
{
    public event Action<Player> Detect;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Player player)) 
            Detect?.Invoke(player);
    }
}