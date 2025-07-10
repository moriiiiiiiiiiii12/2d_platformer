using System;
using UnityEngine;


public class Movement : MonoBehaviour
{
    [SerializeField] private float _speedMove = 20f;
    [SerializeField] private Rigidbody2D _rigidbody2d;

    public event Action<bool> RunChange;
    public event Action<bool> SideChange;

    private bool _side = true;

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

            if (_side == false && inputX > 0)
            {
                _side = true;
                SideChange?.Invoke(_side);
            }
            else if (_side == true && inputX < 0)
            {
                _side = false;
                SideChange?.Invoke(_side);
            }
        }
        else
        {
            RunChange?.Invoke(false);
        }
    }
}
