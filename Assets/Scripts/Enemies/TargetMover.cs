using UnityEngine;

class TargetMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private SpriteFlipper _spriteFlipper;
    [SerializeField] private float _speed;
    [SerializeField] private float _stopDistance = 1.2f;

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        Vector2 targetPosition = _target.position;
        Vector2 currentPosition = transform.position;

        if (Vector2Extension.IsEnoughClose(targetPosition, currentPosition, _stopDistance))
            return;

        Vector2 direction = (targetPosition - currentPosition).normalized;

        bool isMovingLeft = direction.x < 0f;
        _spriteFlipper.Flip(isMovingLeft);

        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
    }
}