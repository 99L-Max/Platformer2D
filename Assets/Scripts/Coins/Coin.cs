using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Coin : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D { get; private set; }

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CoinCollector collector))
        {
            collector.Add();
            Destroy(gameObject);
        }
    }
}
