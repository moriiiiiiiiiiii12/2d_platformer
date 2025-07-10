using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Movement _movement;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private bool _isAscending;
    private bool _isFalling;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<Movement>();
        _jumper = GetComponent<Jumper>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

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
        _animator.SetBool("Jump", isJumping);
    }

    private void OnRunChanged(bool isRunning)
    {
        _animator.SetBool("Run", isRunning && _jumper.OnGrounded == true && _animator.GetBool("Jump") == false);
    }

    private void OnSideChanged(bool faceRight)
    {
        _spriteRenderer.flipX = !faceRight;
    }

    private void OnAscendChanged(bool isAscending)
    {
        _isAscending = isAscending;
        _animator.SetBool("IsAscending", isAscending && _jumper.OnGrounded == false);
    }

    private void OnFallChanged(bool isFalling)
    {
        _isFalling = isFalling;
        _animator.SetBool("IsFalling", isFalling && _jumper.OnGrounded == false);
    }
}
