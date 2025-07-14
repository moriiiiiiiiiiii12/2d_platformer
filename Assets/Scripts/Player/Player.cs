using UnityEngine;

class Player : MonoBehaviour
{
    [SerializeField] Jumper _jumper;
    [SerializeField] Movement _movement;
    [SerializeField] InputReader _inputReader;
    [SerializeField] PlayerAnimator _playerAnimator;
    [SerializeField] GroundChecker _groundChecker;

    private void OnEnable()
    {
        _inputReader.PressJumpInput += _jumper.Jump;
        _jumper.ChangeAscending += Ascending;
        _jumper.ChangeFalling += Falling;
    }

    private void OnDisable()
    {
        _inputReader.PressJumpInput -= _jumper.Jump;
        _jumper.ChangeAscending -= Ascending;
        _jumper.ChangeFalling -= Falling;
    }

    private void Update()
    {
        float horizontalInput = _inputReader.HorizontalAxis;

        bool IsOnGround = _groundChecker.IsOnGround;

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

    private void Ascending(bool isAscending)
    {
        _playerAnimator.SetAscend(isAscending);
    }

    private void Falling(bool isFalling)
    {
        _playerAnimator.SetFall(isFalling);
    }
}