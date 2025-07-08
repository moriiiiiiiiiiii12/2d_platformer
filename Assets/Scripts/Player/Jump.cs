using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpPower = 10f;
    [SerializeField] private Rigidbody2D _rigidbody2d;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _checkDistance = 1f;

    private void Update()
    {
        Jump();
    }


    private void Jump()
    {
        bool buttonPressed = Input.GetAxisRaw("Jump") == 1;
        bool onGround = Physics2D.Raycast(transform.position, Vector2.down, _checkDistance, _layerMask).collider != null;

        if (buttonPressed && onGround)
        {
            _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, _jumpPower);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - _checkDistance));
    }
}
