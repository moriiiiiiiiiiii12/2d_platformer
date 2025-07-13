using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private static readonly int RunHash = Animator.StringToHash("Run");
    private static readonly int JumpHash = Animator.StringToHash("Jump");
    private static readonly int AscendHash = Animator.StringToHash("IsAscending");
    private static readonly int FallHash = Animator.StringToHash("IsFalling");
    
    private bool _isJumping;

    public void OnJumpChanged(bool isJumping)
    {
        _isJumping = isJumping;
        _animator.SetBool(JumpHash, isJumping);
    }

    public void OnRunChanged(bool isRunning)
    {
        bool shouldRun = isRunning && _isJumping == false;
        _animator.SetBool(RunHash, shouldRun);
    }

    public void OnSideChanged(bool isLeft)
    {
        float yRotation = isLeft ? 180f : 0f;
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    public void OnAscendChanged(bool isAscending)
    {
        _animator.SetBool(AscendHash, isAscending);
    }

    public void OnFallChanged(bool isFalling)
    {
        _animator.SetBool(FallHash, isFalling);
    }
}
