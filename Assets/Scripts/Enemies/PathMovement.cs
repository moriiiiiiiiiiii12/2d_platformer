using System.Linq;
using UnityEngine;

public class PathMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private Path _path;
    [SerializeField] private float _distanceTarget = 0.1f;

    private Transform[] _waypoints => _path.Waypoints.ToArray();

    private int _indexCurrentWaypoint;

    private void Update()
    {
        Transform waypoint = _waypoints[_indexCurrentWaypoint];
        transform.position = Vector2.MoveTowards(transform.position, waypoint.position, _speed * Time.deltaTime);

        if (Vector2Extension.IsEnoughClose(transform.position, waypoint.position, _distanceTarget))
            ChooseNextWaypoint();
    }

    private void ChooseNextWaypoint()
    { 
        _indexCurrentWaypoint = ++_indexCurrentWaypoint % _waypoints.Length;
    }
}
