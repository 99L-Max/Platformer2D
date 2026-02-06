using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public abstract class Coin : MonoBehaviour
{
    protected void GiveSelf(CoinTaker taker)
    {
        taker.Take(1);
        Destroy(gameObject);
    }
}
