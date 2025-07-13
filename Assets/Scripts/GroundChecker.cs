using UnityEngine;

class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _checkDistance = 1f;

    public bool CheckIsOnGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, _checkDistance, _layerMask).collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - _checkDistance));
    }
}