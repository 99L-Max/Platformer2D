using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Animator _animator;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private PlayerAttaker _attaker;
    [SerializeField] private Health _health;

    private PlayerActions _actions;
    private Rotator _rotator;

    private void Awake()
    {
        _actions = new PlayerActions();
        _rotator = new Rotator();
    }

    private void OnEnable()
    {
        _actions.PlayerInput.Move.started += Move;
        _actions.PlayerInput.Move.canceled += Move;
        _actions.PlayerInput.Jump.started += Jump;
        _actions.PlayerInput.Attack.started += Attack;

        _groundChecker.ValueChanged += UpdateAnimationJumping;
        _health.Died += OnDied;

        _actions.Enable();
    }

    private void OnDisable()
    {
        _actions.PlayerInput.Move.started -= Move;
        _actions.PlayerInput.Move.canceled -= Move;
        _actions.PlayerInput.Jump.started -= Jump;
        _actions.PlayerInput.Attack.started -= Attack;

        _groundChecker.ValueChanged -= UpdateAnimationJumping;
        _health.Died -= OnDied;

        _actions.Disable();
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
        _rotator.SetDirectionX(_player.transform, direction.x);
    }

    private void UpdateAnimationJumping(bool isGrounted)
    {
        _animator.SetBool(AnimatorData.PlayerParams.IsJumping, isGrounted == false);
    }

    private void Attack(InputAction.CallbackContext callback)
    {
        _attaker.TryAttack();
    }

    private void OnDied()
    {
        _player.gameObject.SetActive(false);
    }
}
