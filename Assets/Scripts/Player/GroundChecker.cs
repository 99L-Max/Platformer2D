using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _checkRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;

    public bool IsGrounded { get; private set; }

    private void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(transform.position, _checkRadius, _groundLayer);
    }
}
