using UnityEngine;


public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Movement _movement;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private bool _isJumping;

    private void OnEnable()
    {
        _movement.RunChange += OnRunChanged;
        _movement.SideChange += OnSideChanged;
        _jumper.JumpingChange += OnJumpChanged;
        _jumper.AscendChange += OnAscendChanged;
        _jumper.FallChange += OnFallChanged;
    }

    private void OnDisable()
    {
        _movement.RunChange -= OnRunChanged;
        _movement.SideChange -= OnSideChanged;
        _jumper.JumpingChange -= OnJumpChanged;
        _jumper.AscendChange -= OnAscendChanged;
        _jumper.FallChange -= OnFallChanged;
    }

    private void OnJumpChanged(bool isJumping)
    {
        _isJumping = isJumping;

        _animator.SetBool("Jump", isJumping);
    }

    private void OnRunChanged(bool isRunning)
    {
        bool canRun = _jumper.IsOnGround && !_isJumping;
        bool shouldRun = isRunning && canRun;

        _animator.SetBool("Run", shouldRun);
    }

    private void OnSideChanged(bool isLeft)
    {
        _spriteRenderer.flipX = isLeft;
    }

    private void OnAscendChanged(bool isAscending)
    {
        bool canAscend = _jumper.IsOnGround == false;
        bool shouldAscend = isAscending && canAscend;

        _animator.SetBool("IsAscending", shouldAscend);
    }

    private void OnFallChanged(bool isFalling)
    {
        bool canFall = _jumper.IsOnGround == false;
        bool shouldFall = isFalling && canFall;

        _animator.SetBool("IsFalling", shouldFall);
    }
}
