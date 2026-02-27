using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Animator _animator;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private PlayerAttaker _attaker;

    private PlayerActions _actions;
    private Rotator _rotator;

    protected override void OnEnable()
    {
        base.OnEnable();

        _actions.PlayerInput.Move.started += Move;
        _actions.PlayerInput.Move.canceled += Move;
        _actions.PlayerInput.Jump.started += Jump;
        _actions.PlayerInput.Attack.started += Attack;

        _groundChecker.ValueChanged += UpdateAnimationJumping;
        _actions.Enable();
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        _actions.PlayerInput.Move.started -= Move;
        _actions.PlayerInput.Move.canceled -= Move;
        _actions.PlayerInput.Jump.started -= Jump;
        _actions.PlayerInput.Attack.started -= Attack;

        _groundChecker.ValueChanged -= UpdateAnimationJumping;
        _actions.Disable();
    }

    private void Awake()
    {
        _actions = new PlayerActions();
        _rotator = new Rotator();
    }

    private void Jump(InputAction.CallbackContext callback)
    {
        if (_groundChecker.IsGrounded)
        {
            _mover.Jump();
        }
    }

    private void Move(InputAction.CallbackContext callback)
    {
        var direction = callback.ReadValue<Vector2>();
        var isRunning = direction.x != 0f;

        _mover.Move(direction);
        _animator.SetBool(AnimatorData.PlayerParams.IsRunning, isRunning);
        _rotator.SetDirectionX(transform, direction.x);
    }

    private void UpdateAnimationJumping(bool isGrounted)
    {
        _animator.SetBool(AnimatorData.PlayerParams.IsJumping, isGrounted == false);
    }

    private void Attack(InputAction.CallbackContext callback)
    {
        _attaker.TryAttack();
    }

    protected override void OnDied()
    {
        _animator.SetBool(AnimatorData.PlayerParams.IsDied, true);
        base.OnDied();
    }
}
