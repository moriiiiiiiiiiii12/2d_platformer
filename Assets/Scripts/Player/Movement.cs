using System;
using UnityEngine;


public class Movement : MonoBehaviour
{
    [SerializeField] private float _speedMove = 20f;
    [SerializeField] private Rigidbody2D _rigidbody2d;

    public event Action<bool> RunChange;
    public event Action<bool> SideChange;

    private bool _isLeft = false;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float inputX = Input.GetAxis("Horizontal");

        if (inputX != 0)
        {
            _rigidbody2d.velocity = new Vector2(inputX * _speedMove, _rigidbody2d.velocity.y);

            RunChange?.Invoke(true);

            if (_isLeft == false && inputX < 0)
            {
                SetSide(true);
            }
            else if (_isLeft == true && inputX > 0)
            {
                SetSide(false);
            }
        }
        else
        {
            RunChange?.Invoke(false);
        }
    }

    private void SetSide(bool isLeft)
    {
        _isLeft = isLeft;
        SideChange?.Invoke(_isLeft);
    }
}
