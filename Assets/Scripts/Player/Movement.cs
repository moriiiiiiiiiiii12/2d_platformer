using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Rigidbody2D _rigidbody2d;
    [SerializeField] private float _speedMove;

    private bool _isLeft = false;

    private void Update()
    {
        Move(_inputReader.HorizontalAxis);
    }

    private void Move(float inputX)
    {
        if (inputX != 0)
        {
            _rigidbody2d.velocity = new Vector2(inputX * _speedMove, _rigidbody2d.velocity.y);

            _playerAnimator.OnRunChanged(true);

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
            _playerAnimator.OnRunChanged(false);
        }
    }

    private void SetSide(bool isLeft)
    {
        _isLeft = isLeft;
        _playerAnimator.OnSideChanged(_isLeft);
    }
}
