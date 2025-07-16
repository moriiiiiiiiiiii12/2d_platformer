using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private SpriteFlipper _spriteFlipper;
    [SerializeField] private Rigidbody2D _rigidbody2d;
    [SerializeField] private float _speedMove;

    private bool _isLeft = false;

    public void Move(float inputX)
    {
        _rigidbody2d.velocity = new Vector2(inputX * _speedMove, _rigidbody2d.velocity.y);

        if (_isLeft == false && inputX < 0)
        {
            _isLeft = true;
            _spriteFlipper.Flip(_isLeft);
        }
        else if (_isLeft == true && inputX > 0)
        {
            _isLeft = false;
            _spriteFlipper.Flip(_isLeft);
        }
    }
}
