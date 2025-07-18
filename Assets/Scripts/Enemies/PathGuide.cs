using System.Linq;
using UnityEngine;

public class PathGuide : MonoBehaviour
{
    [SerializeField] private Path _path;
    [SerializeField] private float _distanceTarget = 0.1f;

    private Transform[] _waypoints = new Transform[0];
    private int _currentIndex;

    private void Awake()
    {
        if (_path != null)
            InitializePath(_path);
    }

    private void InitializePath(Path path)
    {
        _path = path;
        _waypoints = path.Waypoints?.ToArray() ?? new Transform[0];
        _currentIndex = 0;
    }

    public void SetPath(Path newPath)
    {
        InitializePath(newPath);
    }

    public Vector2 GetDirection(Vector3 currentPosition3D)
    {
        if (_waypoints.Length == 0)
            return Vector2.zero;

        Vector2 currentPosition = currentPosition3D;
        Vector2 targetPosition = _waypoints[_currentIndex].position;

        if (currentPosition.IsEnoughClose(targetPosition, _distanceTarget))
        {
            _currentIndex = (_currentIndex + 1) % _waypoints.Length;
            targetPosition = _waypoints[_currentIndex].position;
        }

        return (targetPosition - currentPosition).normalized;
    }
}
