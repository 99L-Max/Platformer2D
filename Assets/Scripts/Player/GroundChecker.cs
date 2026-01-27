using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _checkRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;

    private bool _isGrounded;

    public event Action<bool> ValueChanged;

    public bool IsGrounded 
    {
        get => _isGrounded;
        private set => ChangeValue(value);
    }

    private void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(transform.position, _checkRadius, _groundLayer);
    }

    private void ChangeValue(bool isGrounted)
    {
        if (_isGrounded != isGrounted)
        {
            _isGrounded = isGrounted;
            ValueChanged?.Invoke(isGrounted);
        }
    }
}
