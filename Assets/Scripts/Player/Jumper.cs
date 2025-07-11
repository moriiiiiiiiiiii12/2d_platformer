using System;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpPower = 10f;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _checkDistance = 1f;

    [SerializeField] private float _fallThreshold = -0.1f;
    [SerializeField] private float _ascendThreshold = 0.5f;

    public bool OnGround { get; private set; }

    public event Action<bool> JumpingChange;
    public event Action<bool> AscendChange;
    public event Action<bool> FallChange;

    private void Update()
    {
        Jump();
    }

    private void Jump()
    {
        bool isButtonPress = Input.GetAxisRaw("Jump") == 1;
        OnGround = Physics2D.Raycast(transform.position, Vector2.down, _checkDistance, _layerMask).collider != null;

        JumpingChange?.Invoke(isButtonPress);

        if (isButtonPress && OnGround)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpPower);
        }

        float velocityY = _rigidbody2D.velocity.y;
        FallChange?.Invoke(velocityY < _fallThreshold);
        AscendChange?.Invoke(velocityY > _ascendThreshold);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - _checkDistance));
    }
}
