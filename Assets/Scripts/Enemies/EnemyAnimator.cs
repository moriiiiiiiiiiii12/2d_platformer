using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private PathMovement _movement;

    private void OnEnable()
    {
        _movement.SideChange += OnSideChanged;
    }

    private void OnDisable()
    {
        _movement.SideChange -= OnSideChanged;
    }

    private void OnSideChanged(bool faceRight)
    {
        _spriteRenderer.flipX = !faceRight;
    }
}
