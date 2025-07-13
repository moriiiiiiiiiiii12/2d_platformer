using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _jumpPower = 10f;
    [SerializeField] private float _checkDistance = 1f;

    [SerializeField] private float _fallThreshold = -0.5f;
    [SerializeField] private float _ascendThreshold = 0.5f;

    public bool IsOnGround { get; private set; }

    private bool _prevAscending = false;
    private bool _prevFalling = false;

    private void OnEnable()
    {
        _inputReader.PressJumpInput += Jump;
    }

    private void OnDisable()
    {
        _inputReader.PressJumpInput -= Jump;
    }

    private void Update()
    {
        UpdateJumpState();
    }

    private void Jump()
    {
        IsOnGround = CheckIsOnGround();

        if (IsOnGround)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpPower);
        }
    }

    private void UpdateJumpState()
    {
        float velocityY = _rigidbody2D.velocity.y;
        bool falling = velocityY < _fallThreshold;
        bool ascending = velocityY > _ascendThreshold;

        IsOnGround = CheckIsOnGround();

        if (ascending != _prevAscending)
        {
            _prevAscending = ascending && IsOnGround == false;
            _playerAnimator.OnAscendChanged(_prevAscending);
        }

        if (falling != _prevFalling)
        {
            _prevFalling = falling && IsOnGround == false;
            _playerAnimator.OnFallChanged(_prevFalling);
        }

        _playerAnimator.OnJumpChanged(IsOnGround == false);
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
