using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2d;
    [SerializeField] private float _speedMove;

    private bool _isLeft = false;

    public void Move(float inputX)
    {
        _rigidbody2d.velocity = new Vector2(inputX * _speedMove, _rigidbody2d.velocity.y);

        if (_isLeft == false && inputX < 0)
        {
            SetSide(true);
        }
        else if (_isLeft == true && inputX > 0)
        {
            SetSide(false);
        }
    }

    private void SetSide(bool isLeft)
    {
        _isLeft = isLeft;

        float yRotation = isLeft ? 180f : 0f;
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
