using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private PathGuide _pathGuide;
    [SerializeField] private Path _path;
    [SerializeField] private DirectionalMover _directionMover;
    [SerializeField] private TargetMover _targetMover;
    [SerializeField] private DetectionRadius _detectRadius;

    private void OnEnable()
    {
        _detectRadius.Detect += Follow;
    }

    private void OnDisable()
    {
        _detectRadius.Detect -= Follow;
    }

    private void Start()
    {
        _targetMover.enabled = false;
        _pathGuide.SetPath(_path);
    }

    private void Update()
    {   
        Vector2 direction = _pathGuide.GetDirection(transform.position);
        _directionMover.SetDirection(direction);
    }

    private void Follow(Player target)
    {
        _directionMover.enabled = false;

        _targetMover.SetTarget(target.transform);
        _targetMover.enabled = true;
    }
}