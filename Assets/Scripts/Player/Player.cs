using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Jumper _jumper;
    [SerializeField] private Mover _movement;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private Health _health;

    private bool IsOnGround => _groundChecker.IsOnGround;

    private void OnEnable()
    {
        _inputReader.AttackInput += Attack;
        _inputReader.PressJumpInput += Jump;

        _jumper.ChangeAscending += Ascending;
        _jumper.ChangeFalling += Falling;

        _health.TookDamage += TookDamage;
    }

    private void OnDisable()
    {
        _inputReader.AttackInput -= Attack;
        _inputReader.PressJumpInput -= Jump;

        _jumper.ChangeAscending -= Ascending;
        _jumper.ChangeFalling -= Falling;

        _health.TookDamage -= TookDamage;
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

    private void Attack()
    {
        _playerAnimator.TriggerAttack();
        _attacker.Attack();
    }

    private void TookDamage()
    {
        _playerAnimator.TriggerTakeDamage();
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