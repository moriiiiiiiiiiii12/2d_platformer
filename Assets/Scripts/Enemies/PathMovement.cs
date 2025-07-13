using System;
using System.Linq;
using UnityEngine;

public class PathMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private Path _path;
    [SerializeField] private float _distanceTarget = 0.1f;

    private Transform[] Waypoints => _path.Waypoints.ToArray();

    private int _indexCurrentWaypoint;
    private bool _isMovingRight = true;

    private void Update()
    {
        Transform waypoint = Waypoints[_indexCurrentWaypoint];
        transform.position = Vector2.MoveTowards(transform.position, waypoint.position, _speed * Time.deltaTime);

        float deltaX = waypoint.position.x - transform.position.x;
        bool newIsMovingRight = deltaX >= 0f;

        if (newIsMovingRight != _isMovingRight)
        {
            _isMovingRight = newIsMovingRight;
            SetSide(_isMovingRight);
        }

        if (Vector2Extension.IsEnoughClose(transform.position, waypoint.position, _distanceTarget))
            ChooseNextWaypoint();
    }

    private void ChooseNextWaypoint()
    {
        _indexCurrentWaypoint = ++_indexCurrentWaypoint % Waypoints.Length;
    }

    private void SetSide(bool isRight)
    {
        _isMovingRight = isRight;

        float yRotation = isRight ? 180f : 0f;
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
