using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speedMove = 20f;
    [SerializeField] private Rigidbody2D _rigidbody2d;
    
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float inputX = Input.GetAxis("Horizontal");

        _rigidbody2d.velocity = new Vector2(inputX * _speedMove, _rigidbody2d.velocity.y);
    }
}
