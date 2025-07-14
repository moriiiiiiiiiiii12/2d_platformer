using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _checkDistance = 1f;
    [SerializeField] [Min(0.01f)] private float _checkInterval = 0.1f;
    [SerializeField] private Vector2 _checkBoxSize = new Vector2(1f, 0.1f);

    public bool IsOnGround { get; private set; }

    private void Start()
    {
        StartCoroutine(UpdateGroundStatusRoutine());
    }

    private IEnumerator UpdateGroundStatusRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_checkInterval);

        while (true)
        {
            Vector2 origin = transform.position;
            RaycastHit2D hit = Physics2D.BoxCast(
                origin,
                _checkBoxSize,
                0f,
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
        Vector2 size = _checkBoxSize;
        
        Gizmos.DrawWireCube(origin + Vector2.down * (_checkDistance / 2f), new Vector3(size.x, size.y + _checkDistance, 0f));
    }
}
