using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private static readonly int RunHash = Animator.StringToHash("Run");
    private static readonly int JumpHash = Animator.StringToHash("Jump");
    private static readonly int AscendHash = Animator.StringToHash("IsAscending");
    private static readonly int FallHash = Animator.StringToHash("IsFalling");

    [SerializeField] private Animator _animator;
    
    private bool _isJumping;

    public void SetJump(bool isJumping)
    {
        _isJumping = isJumping;
        _animator.SetBool(JumpHash, isJumping);
    }

    public void SetRun(bool isRunning)
    {
        bool shouldRun = isRunning && _isJumping == false;
        _animator.SetBool(RunHash, shouldRun);
    }

    public void SetAscend(bool isAscending)
    {
        _animator.SetBool(AscendHash, isAscending);
    }

    public void SetFall(bool isFalling)
    {
        _animator.SetBool(FallHash, isFalling);
    }
}
