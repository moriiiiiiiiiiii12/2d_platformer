using System;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpPower = 10f;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _checkDistance = 1f;

    [SerializeField] private float _fallThreshold = -0.1f;
    [SerializeField] private float _ascendThreshold = 0.1f;

    public bool IsOnGround { get; private set; }

    public event Action<bool> JumpingChange;
    public event Action<bool> AscendChange;
    public event Action<bool> FallChange;

    private bool _prevJumpPressed = false;
    private bool _prevAscending = false;
    private bool _prevFalling = false;

    private void Update()
    {
        HandleJump();
    }

    private void HandleJump()
    {
        const string JumpButton = "Jump";

        bool jumpPressed = Input.GetButtonDown(JumpButton);

        // if (jumpPressed != _prevJumpPressed)
        // {
        //     JumpingChange?.Invoke(jumpPressed); 
        //     _prevJumpPressed = jumpPressed;
        // }

        IsOnGround = CheckIsOnGround();

        if (jumpPressed && IsOnGround)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpPower);
        }

        float velocityY = _rigidbody2D.velocity.y;
        bool falling = velocityY < _fallThreshold;
        bool ascending = velocityY > _ascendThreshold;

        if (ascending != _prevAscending)
        {
            AscendChange?.Invoke(ascending);
            _prevAscending = ascending;
        }

        if (falling != _prevFalling)
        {
            FallChange?.Invoke(falling && IsOnGround == false);
            _prevFalling = falling;
        }
    }

    private bool CheckIsOnGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, _checkDistance, _layerMask).collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - _checkDistance));
    }
}
