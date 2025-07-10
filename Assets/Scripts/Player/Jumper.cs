using System;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpPower = 10f;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _checkDistance = 1f;

    public bool OnGrounded { get; private set; }

    public event Action<bool> JumpingChange;
    public event Action<bool> AscendChange;
    public event Action<bool> FallChange;

    private void Update()
    {
        Jump();
    }

    private void Jump()
    {
        bool buttonPressed = Input.GetAxisRaw("Jump") == 1;
        OnGrounded = Physics2D.Raycast(transform.position, Vector2.down, _checkDistance, _layerMask).collider != null;

        JumpingChange?.Invoke(buttonPressed);

        if (buttonPressed && OnGrounded)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpPower);
        }

        float vy = _rigidbody2D.velocity.y;
        FallChange?.Invoke(vy < -0.1f);
        AscendChange?.Invoke(vy > 0.5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - _checkDistance));
    }
}
