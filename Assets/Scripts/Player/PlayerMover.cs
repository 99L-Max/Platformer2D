using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 6f;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private Vector2 _direction;

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_direction.x * _moveSpeed, _rigidbody2D.velocity.y);
    }

    public void Jump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
    }

    public void Move(Vector2 direction)
    {
        _direction = direction;
    }
}
