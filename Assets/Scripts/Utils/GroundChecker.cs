using System.Collections;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _checkDistance = 1f;
    [SerializeField] [Min(0.01f)] private float _checkInterval = 0.1f;
    [SerializeField] private float _checkCircleRadius = 0.5f;

    public bool IsOnGround { get; private set; }

    private void Start()
    {
        StartCoroutine(UpdateGroundStatusRoutine());
    }

    private IEnumerator UpdateGroundStatusRoutine()
    {
        var wait = new WaitForSeconds(_checkInterval);
        while (enabled)
        {
            Vector2 origin = transform.position;
            RaycastHit2D hit = Physics2D.CircleCast(
                origin,
                _checkCircleRadius,
                Vector2.down,
                _checkDistance,
                _layerMask
            );

            IsOnGround = hit.collider != null;

            yield return wait;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector2 origin = transform.position;

        Vector2 bottomCenter = origin + Vector2.down * _checkDistance;

        Gizmos.DrawWireSphere(bottomCenter, _checkCircleRadius);
    }
}
