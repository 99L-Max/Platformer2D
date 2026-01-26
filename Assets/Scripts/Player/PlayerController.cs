using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private GroundChecker _groundChecker;

    private PlayerActions _actions;

    private void Awake()
    {
        _actions = new PlayerActions();
    }

    private void OnEnable()
    {
        _actions.PlayerInput.Move.started += Move;
        _actions.PlayerInput.Move.canceled += Move;
        _actions.PlayerInput.Jump.started += Jump;

        _actions.Enable();
    }

    private void OnDisable()
    {
        _actions.PlayerInput.Move.started -= Move;
        _actions.PlayerInput.Move.canceled -= Move;
        _actions.PlayerInput.Jump.started -= Jump;

        _actions.Disable();
    }

    private void FixedUpdate()
    {
        _animator.UpdateAnimationJumping(_groundChecker.IsGrounded == false);
    }

    private void Jump(InputAction.CallbackContext callback)
    {
        if (_groundChecker.IsGrounded)
        {
            _mover.Jump();
            _animator.UpdateAnimationJumping(true);
        }
    }

    private void Move(InputAction.CallbackContext callback)
    {
        var direction = callback.ReadValue<Vector2>();
        var isRunning = direction.x != 0f;

        _mover.Move(direction);
        _animator.SetDirectionX(direction.x);
        _animator.UpdateAnimationRunning(isRunning);
    }
}
