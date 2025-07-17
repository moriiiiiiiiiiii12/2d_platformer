using UnityEngine;

class Player : MonoBehaviour
{
    [SerializeField] private Jumper _jumper;
    [SerializeField] private Mover _movement;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private GroundChecker _groundChecker;

    private bool IsOnGround => _groundChecker.IsOnGround;

    private void OnEnable()
    {
        _inputReader.PressJumpInput += Jump;
        _jumper.ChangeAscending += Ascending;
        _jumper.ChangeFalling += Falling;
    }

    private void OnDisable()
    {
        _inputReader.PressJumpInput -= Jump;
        _jumper.ChangeAscending -= Ascending;
        _jumper.ChangeFalling -= Falling;
    }

    private void Update()
    {
        float horizontalInput = _inputReader.HorizontalAxis;

        _movement.Move(horizontalInput);

        if (IsOnGround)
        {
            if (horizontalInput != 0)
            {
                _playerAnimator.SetRun(true);
            }
            else
            {
                _playerAnimator.SetRun(false);
            }
        }
        else
        {
            _playerAnimator.SetRun(false);
        }

        _playerAnimator.SetJump(IsOnGround == false);
        _jumper.UpdateJumpState(IsOnGround);
    }

    private void Jump()
    {
        if (IsOnGround)
            _jumper.Jump();
    }

    private void Ascending(bool isAscending)
    {
        _playerAnimator.SetAscend(isAscending);
    }

    private void Falling(bool isFalling)
    {
        _playerAnimator.SetFall(isFalling);
    }
}