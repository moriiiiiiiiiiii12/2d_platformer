using System;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _jumpPower = 10f;

    [SerializeField] private float _fallThreshold = -0.5f;
    [SerializeField] private float _ascendThreshold = 0.5f;

    private bool _prevAscending = false;
    private bool _prevFalling = false;

    public event Action<bool> ChangeAscending;
    public event Action<bool> ChangeFalling;

    public void Jump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpPower);
    }

    public void UpdateJumpState(bool isOnGround)
    {
        float velocityY = _rigidbody2D.velocity.y;
        bool isFalling = velocityY < _fallThreshold;
        bool isAscending = velocityY > _ascendThreshold;

        if (isAscending != _prevAscending)
        {
            _prevAscending = isAscending && isOnGround == false;
            ChangeAscending?.Invoke(_prevAscending);
        }

        if (isFalling != _prevFalling)
        {
            _prevFalling = isFalling && isOnGround == false;
            ChangeFalling?.Invoke(_prevFalling);
        }
    }
}
