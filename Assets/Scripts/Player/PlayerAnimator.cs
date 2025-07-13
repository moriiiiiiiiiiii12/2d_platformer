using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Movement _movement;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private Transform _visualRoot;

    private bool _isJumping;

    private static readonly int JumpHash   = Animator.StringToHash("Jump");
    private static readonly int RunHash    = Animator.StringToHash("Run");
    private static readonly int AscendHash = Animator.StringToHash("IsAscending");
    private static readonly int FallHash   = Animator.StringToHash("IsFalling");

    private Vector3 _initialScale;

    private void Awake()
    {
        if (_visualRoot == null)
            _visualRoot = transform;

        _initialScale = _visualRoot.localScale;
    }

    private void OnEnable()
    {
        _movement.RunChange   += OnRunChanged;
        _movement.SideChange  += OnSideChanged;
        _jumper.JumpingChange += OnJumpChanged;
        _jumper.AscendChange  += OnAscendChanged;
        _jumper.FallChange    += OnFallChanged;
    }

    private void OnDisable()
    {
        _movement.RunChange   -= OnRunChanged;
        _movement.SideChange  -= OnSideChanged;
        _jumper.JumpingChange -= OnJumpChanged;
        _jumper.AscendChange  -= OnAscendChanged;
        _jumper.FallChange    -= OnFallChanged;
    }

    private void OnJumpChanged(bool isJumping)
    {
        _isJumping = isJumping;
        _animator.SetBool(JumpHash, isJumping);
    }

    private void OnRunChanged(bool isRunning)
    {
        bool canRun    = _jumper.IsOnGround && _isJumping == false;
        bool shouldRun = isRunning && canRun;
        _animator.SetBool(RunHash, shouldRun);
    }

    private void OnSideChanged(bool isLeft)
    {
        float direction = isLeft ? -1f : 1f;
        Vector3 scale   = _initialScale;
        scale.x = Mathf.Abs(scale.x) * direction;
        _visualRoot.localScale = scale;
    }

    private void OnAscendChanged(bool isAscending)
    {
        _animator.SetBool(AscendHash, isAscending);
    }

    private void OnFallChanged(bool isFalling)
    {
        _animator.SetBool(FallHash, isFalling);
    }
}
