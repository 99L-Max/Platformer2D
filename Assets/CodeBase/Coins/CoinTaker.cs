using UnityEngine;

public class CoinTaker : MonoBehaviour 
{
    [SerializeField] private Wallet _wallet;

    public void Take(int coinsCount = 1)
    {
        if (coinsCount > 0)
        {
            _wallet.Add(coinsCount);
        }
    }
}
