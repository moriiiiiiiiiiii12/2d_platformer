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
        _jumper.AscendChange -= OnAscendChanged;
        _jumper.FallChange -= OnFallChanged;
    }

    private void OnJumpChanged(bool isJumping)
    {
        _isJumping = isJumping;
        bool shouldJump = isJumping;

        _animator.SetBool("Jump", shouldJump);
    }

    private void OnRunChanged(bool isRunning)
    {
        bool canRun = _jumper.OnGrounded && !_isJumping;
        bool shouldRun = isRunning && canRun;

        _animator.SetBool("Run", shouldRun);
    }

    private void OnSideChanged(bool faceRight)
    {
        bool shouldFlip = !faceRight;
        _spriteRenderer.flipX = shouldFlip;
    }

    private void OnAscendChanged(bool isAscending)
    {
        bool canAscend = !_jumper.OnGrounded;
        bool shouldAscend = isAscending && canAscend;

        _animator.SetBool("IsAscending", shouldAscend);
    }

    private void OnFallChanged(bool isFalling)
    {
        bool canFall = !_jumper.OnGrounded;
        bool shouldFall = isFalling && canFall;

        _animator.SetBool("IsFalling", shouldFall);
    }
}
