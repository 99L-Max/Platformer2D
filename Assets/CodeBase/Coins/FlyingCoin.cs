using UnityEngine;

public class FlyingCoin : Coin
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out CoinTaker taker))
        {
            GiveSelf(taker);
        }
    }
}
