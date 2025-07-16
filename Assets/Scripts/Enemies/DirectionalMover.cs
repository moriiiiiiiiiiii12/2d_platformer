using UnityEngine;

[RequireComponent(typeof(Transform))]
public class DirectionalMover : MonoBehaviour
{
    [SerializeField] private SpriteFlipper _spriteFlipper;
    [SerializeField] private float _speed = 3f;
    private Vector2 _direction;

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
    }

    private void Update()
    {
        if (_direction == Vector2.zero)
            return;

        Move();

        bool isMovingLeft = _direction.x < 0f;
        _spriteFlipper.Flip(isMovingLeft);
    }

    private void Move()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
    }
}
