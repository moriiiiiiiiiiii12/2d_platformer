using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private PathGuide _pathGuide;
    [SerializeField] private Path _path;
    [SerializeField] private DirectionalMover _mover;

    private void Start()
    {
        _pathGuide.SetPath(_path);
    }

    private void Update()
    {
        Vector2 direction = _pathGuide.GetDirection(transform.position);
        _mover.SetDirection(direction);
    }
}