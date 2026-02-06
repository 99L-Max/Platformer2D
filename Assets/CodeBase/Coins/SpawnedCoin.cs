using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SpawnedCoin : Coin
{
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CoinTaker taker))
        {
            GiveSelf(taker);
        }
    }

    public void Flip(float radius, float force)
    {
        var speedX = Random.Range(-radius, radius);
        _rigidbody2D.velocity = new Vector2(speedX, force);
    }
}
